using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<BankAccount> FindBankAccountsByUsername(string username)
    {
        const string sql = """
                           select account_number, user_name, money_amount
                           from bank_accounts
                           where user_name = :username;
                           """;

        ArgumentNullException.ThrowIfNull(_connectionProvider);
        ValueTask<NpgsqlConnection> valueTask = _connectionProvider
            .GetConnectionAsync(default);

        if (!valueTask.IsCompleted)
        {
            yield break;
        }

        NpgsqlConnection connection = valueTask.GetAwaiter().GetResult();

        connection.Open();
        using var npgsqlCommand = new NpgsqlCommand(sql, connection);
        using NpgsqlCommand command = npgsqlCommand.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new BankAccount(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetInt32(2));
        }

        connection.Close();
    }

    public BankAccount? FindBankAccount(long accountNumber)
    {
        const string sql = """
                           select account_number, user_name, money_amount
                           from bank_accounts
                           where account_number = :accountNumber;
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
        using NpgsqlCommand command = npgsqlCommand.AddParameter("accountNumber", accountNumber);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        long accountNumberReader = reader.GetInt64(0);
        string username = reader.GetString(1);
        int moneyAmount = reader.GetInt32(2);

        connection.Close();

        return new BankAccount(accountNumberReader, username, moneyAmount);
    }

    public void CreateBankAccount(string username)
    {
        const string sql = """
                           insert into bank_accounts(user_name, money_amount)
                           values (:username, 0);
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
            .AddParameter("username", username);

        command.ExecuteNonQuery();

        connection.Close();
    }

    public bool UpdateMoneyAmount(long accountNumber, int newMoneyAmount)
    {
        const string sql = """
                            update bank_accounts set money_amount = :newMoneyAmount
                            where account_number = :accountNumber;
                            """;
        ArgumentNullException.ThrowIfNull(_connectionProvider);
        ValueTask<NpgsqlConnection> valueTask = _connectionProvider
            .GetConnectionAsync(default);

        if (!valueTask.IsCompleted)
        {
            return false;
        }

        NpgsqlConnection connection = valueTask.GetAwaiter().GetResult();

        connection.Open();
        using var secondSqlCommand = new NpgsqlCommand(sql, connection);
        using NpgsqlCommand command = secondSqlCommand
            .AddParameter("newMoneyAmount", newMoneyAmount)
            .AddParameter("accountNumber", accountNumber);
        command.ExecuteNonQuery();
        connection.Close();

        return true;
    }
}