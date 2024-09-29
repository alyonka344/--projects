using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface ITransactionHistoryRepository
{
    IEnumerable<BankOperation> FindTransactionHistory(long accountNumber);
    void AddOperation(
        string username,
        long accountNumber,
        OperationType operationType,
        OperationResult operationResult,
        int moneyAmount);
}