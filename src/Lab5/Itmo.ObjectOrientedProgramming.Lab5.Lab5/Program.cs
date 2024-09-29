using Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5;

public static class Program
{
    public static void Main()
    {
        var collection = new ServiceCollection();
        var configuration = new Configuration("Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=05052004;");
        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration.ConnectionString);

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        IUserService userService = scope.ServiceProvider.GetRequiredService<IUserService>();

        if (userService.Login("alyona", 505) is LoginResult.Success)
        {
           Console.WriteLine("успешно");
        }

        if (userService.CreateAccount() is OperationResult.Success)
        {
            Console.WriteLine("\nуспешно");
        }

        if (userService.MoneyReceiving(1, 100) is OperationResult.Success)
        {
            Console.WriteLine("\nуспешно");
        }

        if (userService.WithdrawMoney(1, 150) is OperationResult.Success)
        {
            Console.WriteLine("\nуспешно");
        }
    }
}