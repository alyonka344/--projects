using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionHistoryRepository : ITransactionHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionHistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<BankOperation> FindTransactionHistory(long accountNumber)
    {
        const string sql = """
                           select number, user_name, account_number,
                           operation_type, operation_result, money_amount
                           from transaction_history
                           where account_number = :accountNumber;
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
        using NpgsqlCommand command = npgsqlCommand.AddParameter("accountNumber", accountNumber);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new BankOperation(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetInt64(2),
                reader.GetFieldValue<OperationType>(3),
                reader.GetFieldValue<OperationResult>(4),
                reader.GetInt32(5));
        }

        connection.Close();
    }

    public void AddOperation(
        string username,
        long accountNumber,
        OperationType operationType,
        OperationResult operationResult,
        int moneyAmount)
    {
        const string sql = """
                           insert into transaction_history(user_name, account_number,
                           operation_type, operation_result, money_amount)
                           values (:username, :accountNumber, :operationType, :operationResult, :moneyAmount);
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
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("operationType", operationType)
            .AddParameter("operationResult", operationResult)
            .AddParameter("moneyAmount", moneyAmount);

        command.ExecuteNonQuery();

        connection.Close();
    }
}