using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginPage(string button, string username, int password)
    {
        if (button == "Log In")
        {
            LoginResult loginResult = _userService.Login(username, password);
            if (loginResult is LoginResult.Success)
            {
                if (_userService.UserManager != null)
                {
                    if (_userService.UserManager.User.UserRole is UserRole.Client)
                    {
                        var pageModel = new UserPageModel(username, _userService.UserManager.BankAccounts);
                        return View("UsersBankAccounts", pageModel);
                    }

                    return View("AdminPage");
                }
            }

            if (loginResult is LoginResult.WrongPassword)
            {
                return View("LoginError");
            }
        }

        if (button == "Sign Up")
        {
            SignUpResult signUpResult = _userService.SignUp(username, password);

            if (signUpResult is SignUpResult.AlreadyRegistered)
            {
                return View("SignUpError");
            }
        }

        return View();
    }

    public IActionResult UsersBankAccounts(string button, int accountNumber, int recipientAccountNumber, int moneyAmount)
    {
        if (_userService.UserManager != null)
        {
            var pageModel = new UserPageModel(
                _userService.UserManager.User.Username,
                _userService.UserManager.BankAccounts);

            if (button == "Withdraw money")
            {
                if (_userService.WithdrawMoney(accountNumber, moneyAmount) == OperationResult.Fail)
                {
                    return View("OperationError");
                }

                return View("UsersBankAccounts", pageModel);
            }

            if (button == "Add money")
            {
                _userService.MoneyReceiving(accountNumber, moneyAmount);
                return View("UsersBankAccounts", pageModel);
            }

            if (button == "Transaction History")
            {
                return View("TransactionHistory", _userService.ViewTransactionHistory(accountNumber));
            }

            if (button == "Transfer money")
            {
                if (_userService.TransferMoney(accountNumber, recipientAccountNumber, moneyAmount) == OperationResult.Fail)
                {
                    return View("OperationError");
                }

                return View("UsersBankAccounts", pageModel);
            }
        }

        return View();
    }

    public IActionResult AddAccount()
    {
        if (_userService.UserManager != null)
        {
            var pageModel = new UserPageModel(
                _userService.UserManager.User.Username,
                _userService.UserManager.BankAccounts);

            _userService.CreateAccount();
            return View("UsersBankAccounts", pageModel);
        }

        return View("LoginError");
    }
}