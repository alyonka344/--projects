using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class UserRepository : IUserRepository
{
    private IEnumerable<User> _users = new[] { new User(1, "alyona", 5050, UserRole.Client) };
    public User? FindUserByUsername(string username)
    {
        return _users.FirstOrDefault(func => func.Username == username);
    }

    public void AddUser(string username, int password)
    {
        throw new System.NotImplementedException();
    }
}