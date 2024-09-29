namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

public interface IDirectory
{
    public string AbsolutePath { get; set; }
    public bool Exists();
}