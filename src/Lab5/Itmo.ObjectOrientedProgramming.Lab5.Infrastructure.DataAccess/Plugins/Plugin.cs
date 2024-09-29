using Itmo.Dev.Platform.Postgres.Plugins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Plugins;

public class Plugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.MapEnum<UserRole>();
        builder.MapEnum<OperationType>();
        builder.MapEnum<OperationResult>();
    }
}