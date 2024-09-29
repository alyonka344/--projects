using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PersonalComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private readonly Repository _repository;

    public Tests()
    {
        var repository = new Repository();
        _repository = RepositoryDirector.CreateDefaultRepository(repository);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator1))]
    public void CreateComputer_SuccessBuild(Type success, Configuration configuration)
    {
        // arrange
        var computerBuilder = new ComputerBuilder();

        // act
        Computer computer = new ComputerDirector(computerBuilder).CreateComputer(configuration, _repository);
        Result result = computer.ValidationResult();

        // assert
        Assert.IsType(success, result);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator2))]
    public void CreateComputer_SuccessBuildButBadPowerUnit(Type badPowerUnit, Configuration configuration)
    {
        // arrange
        var computerBuilder = new ComputerBuilder();

        // act
        Computer computer = new ComputerDirector(computerBuilder).CreateComputer(configuration, _repository);
        Result result = computer.ValidationResult();

        // assert
        Assert.IsType(badPowerUnit, result);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator3))]
    public void CreateComputer_FailWithWarrantyDisclaimer(Type warrantyDisclaimer, Configuration configuration)
    {
        // arrange
        var computerBuilder = new ComputerBuilder();

        // act
        Computer computer = new ComputerDirector(computerBuilder).CreateComputer(configuration, _repository);
        Result result = computer.ValidationResult();

        // assert
        Assert.IsType(warrantyDisclaimer, result);
    }

    [Theory]
    [ClassData(typeof(TestsGenerator4))]
    public void CreateComputer_FailBuild(Type fail, Configuration configuration)
    {
        // arrange
        var repository = new Repository();
        var computerBuilder = new ComputerBuilder();
        var director = new ComputerDirector(computerBuilder);
        repository = RepositoryDirector.CreateDefaultRepository(repository);

        // act
        Computer computer = director.CreateComputer(configuration, repository);
        Result result = computer.ValidationResult();

        // assert
        Assert.IsType(fail, result);
        Assert.Contains("Hdd or Ssd is not exist", computer.ValidationResults.Select(res => res.Comment));
    }
}