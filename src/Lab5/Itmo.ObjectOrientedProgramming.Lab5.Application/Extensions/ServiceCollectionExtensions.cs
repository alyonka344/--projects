using Itmo.ObjectOrientedProgramming.Lab5.Application.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddSingleton<IUserService, UserService>();
        collection.AddSingleton<IBankAccountService, BankAccountService>();

        return collection;
    }
}