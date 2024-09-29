namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public interface ICommand
{
    public void Execute(FileSystemWorkingDirectory fileSystemWorkingDirectory);
}