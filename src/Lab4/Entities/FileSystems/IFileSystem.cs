using Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    public IDirectoryFactory DirectoryFactory { get; }
}