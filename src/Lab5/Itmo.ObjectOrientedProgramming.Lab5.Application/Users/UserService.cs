using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IBankAccountService _bankAccountService;
    private readonly ITransactionHistoryRepository _transactionHistoryRepository;

    public UserService(
        IUserRepository userRepository,
        ITransactionHistoryRepository transactionHistoryRepository,
        IBankAccountService bankAccountService)
    {
        _userRepository = userRepository;
        _transactionHistoryRepository = transactionHistoryRepository;
        _bankAccountService = bankAccountService;
        UserManager = null;
    }

    public UserManager? UserManager { get; private set; }

    public LoginResult Login(string username, int password)
    {
        User? user = _userRepository.FindUserByUsername(username);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        if (user.Password != password)
        {
            return new LoginResult.WrongPassword();
        }

        UserManager = new UserManager(user, _bankAccountService.FindBankAccountsByUsername(user.Username));
        return new LoginResult.Success();
    }

    public SignUpResult SignUp(string username, int password)
    {
        if (_userRepository.FindUserByUsername(username) is not null)
        {
            return new SignUpResult.AlreadyRegistered();
        }

        _userRepository.AddUser(username, password);
        return new SignUpResult.Success();
    }

    public OperationResult CreateAccount()
    {
        if (UserManager is null)
        {
            return OperationResult.Fail;
        }

        _bankAccountService.CreateBankAccount(UserManager.User.Username);
        return OperationResult.Success;
    }

    public OperationResult WithdrawMoney(long accountNumber, int moneyAmount)
    {
        if (UserManager is null)
        {
            return OperationResult.Fail;
        }

        OperationResult operationResult = _bankAccountService.MoneyWithdraw(accountNumber, moneyAmount);
        _transactionHistoryRepository.AddOperation(
            UserManager.User.Username,
            accountNumber,
            OperationType.MoneyWithdraw,
            operationResult,
            moneyAmount);

        return operationResult;
    }

    public OperationResult MoneyReceiving(long accountNumber, int moneyAmount)
    {
        if (UserManager is null)
        {
            return OperationResult.Fail;
        }

        if (UserManager.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber) is null)
        {
            return OperationResult.Fail;
        }

        OperationResult operationResult = _bankAccountService.MoneyReceiving(accountNumber, moneyAmount);
        _transactionHistoryRepository.AddOperation(
            UserManager.User.Username,
            accountNumber,
            OperationType.MoneyReceiving,
            operationResult,
            moneyAmount);

        return operationResult;
    }

    public OperationResult TransferMoney(long senderAccountNumber, long recipientAccountNumber, int moneyAmount)
    {
        if (UserManager is null)
        {
            return OperationResult.Fail;
        }

        if (UserManager.BankAccounts.FirstOrDefault(x => x.AccountNumber == senderAccountNumber) is null)
        {
            return OperationResult.Fail;
        }

        OperationResult operationResult = _bankAccountService.MoneyTransfer(senderAccountNumber, recipientAccountNumber, moneyAmount);
        _transactionHistoryRepository.AddOperation(
            UserManager.User.Username,
            senderAccountNumber,
            OperationType.MoneyTransfer,
            operationResult,
            moneyAmount);

        return operationResult;
    }

    public IEnumerable<BankOperation> ViewTransactionHistory(long accountNumber)
    {
        return UserManager is null ? new List<BankOperation>() :
            _transactionHistoryRepository.FindTransactionHistory(accountNumber);
    }

    public int ViewMoneyAmount(long accountNumber)
    {
        if (UserManager is null)
        {
            return 0;
        }

        BankAccount? bankAccount = _bankAccountService.FindBankAccount(accountNumber);
        return bankAccount?.MoneyAmount ?? 0;
    }

    public IEnumerable<BankAccount> GetAllBankAccounts()
    {
        return UserManager is null ? new List<BankAccount>() :
            _bankAccountService.FindBankAccountsByUsername(UserManager.User.Username).OrderBy(x => x.AccountNumber);
    }
}