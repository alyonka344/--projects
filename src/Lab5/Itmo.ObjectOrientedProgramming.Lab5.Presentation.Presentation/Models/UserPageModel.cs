using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Presentation.Models;

public class UserPageModel
{
    private IEnumerable<BankAccount> bankAccounts;
    public UserPageModel(string username, IEnumerable<BankAccount> bankAccounts)
    {
        Username = username;
        this.bankAccounts = bankAccounts;
    }

    public string Username { get; }
    public IEnumerable<BankAccount> BankAccounts
    {
        get
        {
            return bankAccounts.OrderBy(a => a.AccountNumber);
        }
    }
}