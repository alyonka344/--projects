namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;

public record BankOperation(
    long Number,
    string Username,
    long AccountNumber,
    OperationType OperationType,
    OperationResult OperationResult,
    int MoneyAmount);