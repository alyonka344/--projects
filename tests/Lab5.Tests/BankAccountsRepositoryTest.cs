using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankAccountsRepositoryTest : IBankAccountRepository
{
    private IEnumerable<BankAccount> _bankAccounts = new[]
    {
        new BankAccount(1, "alyona", 5000),
        new BankAccount(2, "alyona", 0),
    };

    public IEnumerable<BankAccount> FindBankAccountsByUsername(string username)
    {
        return _bankAccounts.Where(x => x.Username == username);
    }

    public BankAccount? FindBankAccount(long accountNumber)
    {
        return _bankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
    }

    public void CreateBankAccount(string username)
    {
        throw new System.NotImplementedException();
    }

    public bool UpdateMoneyAmount(long accountNumber, int newMoneyAmount)
    {
        throw new System.NotImplementedException();
    }

    public OperationResult MoneyWithdraw(long accountNumber, int moneyAmount)
    {
        BankAccount? value = _bankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
        if (value != null && value.MoneyAmount < moneyAmount)
        {
            return OperationResult.Fail;
        }

        value?.GetType().GetProperty("MoneyAmount")?.SetValue(value, value.MoneyAmount - moneyAmount);
        return OperationResult.Success;
    }

    public OperationResult MoneyReceiving(long accountNumber, int moneyAmount)
    {
        BankAccount? value = _bankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

        value?.GetType().GetProperty("MoneyAmount")?.SetValue(value, value.MoneyAmount + moneyAmount);
        return OperationResult.Success;
    }
}