using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;

public interface IUserService
{
    public UserManager? UserManager { get; }
    LoginResult Login(string username, int password);
    SignUpResult SignUp(string username, int password);
    OperationResult CreateAccount();
    OperationResult WithdrawMoney(long accountNumber, int moneyAmount);
    OperationResult MoneyReceiving(long accountNumber, int moneyAmount);
    OperationResult TransferMoney(long senderAccountNumber, long recipientAccountNumber, int moneyAmount);
    IEnumerable<BankOperation> ViewTransactionHistory(long accountNumber);
    int ViewMoneyAmount(long accountNumber);
    IEnumerable<BankAccount> GetAllBankAccounts();
}