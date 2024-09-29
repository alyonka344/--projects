using Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public IDirectoryFactory DirectoryFactory { get; } = new LocalDirectoryFactory();
}