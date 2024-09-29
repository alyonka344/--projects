using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class UserManager
{
    public UserManager(User user, IEnumerable<BankAccount> bankAccounts)
    {
        User = user;
        BankAccounts = bankAccounts;
    }

    public User User { get; }
    public IEnumerable<BankAccount> BankAccounts { get; }
}