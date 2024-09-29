using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    private readonly UserService _userService = new UserService(
        new UserRepository(),
        new HistoryRepository(),
        new BankAccountService(
            new BankAccountsRepositoryTest()));

    [Fact]
    public void AddMoneyTest_Success()
    {
        // arrange
        _userService.Login("alyona", 5050);
        int? beforeMoney = _userService.UserManager?.BankAccounts.First(x => x.AccountNumber == 1).MoneyAmount;

        // act
        _userService.MoneyReceiving(1, 200);

        // assert
        Assert.Equal(beforeMoney + 200, _userService.UserManager?.BankAccounts.First(x => x.AccountNumber == 1).MoneyAmount);
    }

    [Fact]
    public void LoginTest_WrongPassword()
    {
        // arrange

        // act
        LoginResult loginResult = _userService.Login("alyona", 505);

        // assert
        Assert.IsType<LoginResult.WrongPassword>(loginResult);
    }

    [Fact]
    public void LoginTest_UserNotFound()
    {
        // arrange

        // act
        LoginResult loginResult = _userService.Login("Makarevich Roman", 2024);

        // assert
        Assert.IsType<LoginResult.NotFound>(loginResult);
    }

    [Fact]
    public void TransferMoneyTest_Success()
    {
        // arrange
        _userService.Login("alyona", 5050);
        int? beforeMoney = _userService.UserManager?.BankAccounts.First(x => x.AccountNumber == 1).MoneyAmount;

        // act
        _userService.WithdrawMoney(1, 600);

        // assert
        Assert.Equal(beforeMoney - 600, _userService.UserManager?.BankAccounts.First(x => x.AccountNumber == 1).MoneyAmount);
    }

    [Fact]
    public void TransferMoneyTest_OperationError()
    {
        // arrange
        _userService.Login("alyona", 5050);
        int? beforeMoney = _userService.UserManager?.BankAccounts.First(x => x.AccountNumber == 1).MoneyAmount;

        // act
        OperationResult result = _userService.WithdrawMoney(1, 6000);

        // assert
        Assert.Equal(OperationResult.Fail, result);
    }
}