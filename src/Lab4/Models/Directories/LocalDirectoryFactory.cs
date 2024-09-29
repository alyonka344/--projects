namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

public class LocalDirectoryFactory : IDirectoryFactory
{
    public IDirectory Create(string path)
    {
        return new LocalDirectory(path);
    }
}