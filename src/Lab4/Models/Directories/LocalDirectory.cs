using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

public class LocalDirectory : IDirectory
{
    public LocalDirectory(string path)
    {
        AbsolutePath = path;
    }

    public string AbsolutePath { get; set; }

    public bool Exists()
    {
        return Directory.Exists(AbsolutePath);
    }
}