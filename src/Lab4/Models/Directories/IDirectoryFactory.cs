namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

public interface IDirectoryFactory
{
    IDirectory Create(string path);
}