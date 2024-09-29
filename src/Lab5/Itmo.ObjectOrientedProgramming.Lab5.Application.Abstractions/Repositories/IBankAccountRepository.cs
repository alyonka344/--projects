using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    IEnumerable<BankAccount> FindBankAccountsByUsername(string username);
    BankAccount? FindBankAccount(long accountNumber);
    void CreateBankAccount(string username);
    bool UpdateMoneyAmount(long accountNumber, int newMoneyAmount);
}