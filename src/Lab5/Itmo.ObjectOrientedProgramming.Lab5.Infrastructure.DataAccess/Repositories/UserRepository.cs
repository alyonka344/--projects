using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username)
    {
        const string sql = """
                           select id, user_name, password, user_role
                           from users
                           where user_name = :username;
                           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        ValueTask<NpgsqlConnection> valueTask = _connectionProvider
            .GetConnectionAsync(default);

        if (!valueTask.IsCompleted)
        {
            return null;
        }

        NpgsqlConnection connection = valueTask.GetAwaiter().GetResult();

        connection.Open();
        using var npgsqlCommand = new NpgsqlCommand(sql, connection);
        using NpgsqlCommand command = npgsqlCommand.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        long id = reader.GetInt64(0);
        string usernameReader = reader.GetString(1);
        long password = reader.GetInt64(2);
        UserRole userRole = reader.GetFieldValue<UserRole>(3);

        connection.Close();

        return new User(id, usernameReader, password, userRole);
    }

    public void AddUser(string username, int password)
    {
        const string sql = """
                           insert into users(user_name, password, user_role)
                           values (:username, :password, 'client');
                           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        ValueTask<NpgsqlConnection> valueTask = _connectionProvider
            .GetConnectionAsync(default);

        if (!valueTask.IsCompleted)
        {
            return;
        }

        NpgsqlConnection connection = valueTask.GetAwaiter().GetResult();

        connection.Open();
        using var npgsqlCommand = new NpgsqlCommand(sql, connection);
        using NpgsqlCommand command = npgsqlCommand
            .AddParameter("username", username)
            .AddParameter("password", password);

        command.ExecuteNonQuery();

        connection.Close();
    }
}