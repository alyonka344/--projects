using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class HistoryRepository : ITransactionHistoryRepository
{
    public IEnumerable<BankOperation> FindTransactionHistory(long accountNumber)
    {
        return new List<BankOperation>();
    }

    public void AddOperation(
        string username,
        long accountNumber,
        OperationType operationType,
        OperationResult operationResult,
        int moneyAmount)
    { }
}