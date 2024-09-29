using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.BankAccounts;

public interface IBankAccountService
{
    OperationResult MoneyWithdraw(long accountNumber, int moneyAmount);
    OperationResult MoneyReceiving(long accountNumber, int moneyAmount);
    OperationResult MoneyTransfer(long senderAccountNumber, long recipientAccountNumber, int moneyAmount);
    IEnumerable<BankAccount> FindBankAccountsByUsername(string username);
    BankAccount? FindBankAccount(long accountNumber);
    void CreateBankAccount(string username);
}