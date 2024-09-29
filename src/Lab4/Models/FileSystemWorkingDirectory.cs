using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class FileSystemWorkingDirectory
{
    public IFileSystem? FileSystem { get; set; }
    public IDirectory? Directory { get; set; }
}