using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Connection;

public class ConnectionProvider : IPostgresConnectionProvider
{
    private readonly NpgsqlDataSource _dataSource;

    public ConnectionProvider(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public ConnectionProvider(string connectionString)
    {
        _dataSource = NpgsqlDataSource.Create(connectionString);
    }

    public ValueTask<NpgsqlConnection> GetConnectionAsync(CancellationToken cancellationToken)
    {
        NpgsqlConnection connection = _dataSource.CreateConnection();
        return new ValueTask<NpgsqlConnection>(connection);
    }
}