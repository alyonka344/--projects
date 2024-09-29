using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private IBankAccountRepository _repository;

    public BankAccountService(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public OperationResult MoneyWithdraw(long accountNumber, int moneyAmount)
    {
        BankAccount? account = _repository.FindBankAccount(accountNumber);
        if (account is null)
        {
            return OperationResult.Fail;
        }

        if (account.MoneyAmount < moneyAmount)
        {
            return OperationResult.Fail;
        }

        int newAmount = account.MoneyAmount - moneyAmount;
        bool success = _repository.UpdateMoneyAmount(accountNumber, newAmount);
        return success ? OperationResult.Success : OperationResult.Fail;
    }

    public OperationResult MoneyReceiving(long accountNumber, int moneyAmount)
    {
        BankAccount? account = _repository.FindBankAccount(accountNumber);
        if (account is null)
        {
            return OperationResult.Fail;
        }

        int newAmount = account.MoneyAmount + moneyAmount;
        bool success = _repository.UpdateMoneyAmount(accountNumber, newAmount);
        return success ? OperationResult.Success : OperationResult.Fail;
    }

    public OperationResult MoneyTransfer(long senderAccountNumber, long recipientAccountNumber, int moneyAmount)
    {
        BankAccount? senderAccount = _repository.FindBankAccount(senderAccountNumber);
        if (senderAccount is null)
        {
            return OperationResult.Fail;
        }

        if (senderAccount.MoneyAmount < moneyAmount)
        {
            return OperationResult.Fail;
        }

        int oldSenderAmount = senderAccount.MoneyAmount;
        int newAmount = senderAccount.MoneyAmount - moneyAmount;
        bool success = _repository.UpdateMoneyAmount(senderAccountNumber, newAmount);

        if (!success)
        {
            return OperationResult.Fail;
        }

        BankAccount? recipientAccount = _repository.FindBankAccount(recipientAccountNumber);
        if (recipientAccount is null)
        {
            return OperationResult.Fail;
        }

        newAmount = recipientAccount.MoneyAmount + moneyAmount;
        success = _repository.UpdateMoneyAmount(recipientAccountNumber, newAmount);

        if (success) return OperationResult.Success;

        _repository.UpdateMoneyAmount(senderAccountNumber, oldSenderAmount);
        return OperationResult.Fail;
    }

    public IEnumerable<BankAccount> FindBankAccountsByUsername(string username)
    {
        return _repository.FindBankAccountsByUsername(username);
    }

    public BankAccount? FindBankAccount(long accountNumber)
    {
        return _repository.FindBankAccount(accountNumber);
    }

    public void CreateBankAccount(string username)
    {
        _repository.CreateBankAccount(username);
    }
}