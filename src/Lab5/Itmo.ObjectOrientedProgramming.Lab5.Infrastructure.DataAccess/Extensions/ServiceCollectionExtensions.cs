using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Plugins;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        string configuration)
    {
        collection.AddSingleton<IPostgresConnectionProvider>(new ConnectionProvider(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, Plugin>();

        collection.AddSingleton<IUserRepository, UserRepository>();
        collection.AddSingleton<IBankAccountRepository, BankAccountRepository>();
        collection.AddSingleton<ITransactionHistoryRepository, TransactionHistoryRepository>();

        return collection;
    }
}