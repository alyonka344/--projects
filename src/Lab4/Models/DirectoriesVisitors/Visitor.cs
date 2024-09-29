using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Directories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoriesVisitors;

public class Visitor : IVisitor<IDirectory>
{
    private readonly IPrinter _printer;
    private readonly int _maxDepth;
    private int _depth;

    public Visitor(int depth)
    {
        _depth = 0;
        _maxDepth = depth;
        _printer = new ConsolePrinter();
    }

    public Visitor(IPrinter printer)
    {
        _printer = printer;
    }

    public void Visit(IDirectory directory)
    {
        ArgumentNullException.ThrowIfNull(directory);

        string indent = string.Concat(Enumerable.Repeat('\t', _depth));
        _printer.Print(indent + directory.AbsolutePath);

        var allFiles = new List<string>();
        if (Directory.Exists(directory.AbsolutePath))
        {
            allFiles.AddRange(Directory.EnumerateFileSystemEntries(directory.AbsolutePath).ToList());
        }

        _depth += 1;

        foreach (string file in allFiles)
        {
            Visit(file);
        }

        _depth -= 1;
    }

    private void Visit(string directory)
    {
        string indent = string.Concat(Enumerable.Repeat('\t', _depth));
        var allFiles = new List<string>();
        if (Directory.Exists(directory))
        {
            _printer.Print(indent + "\ud83d\udcc2" + new DirectoryInfo(directory).Name);
            allFiles.AddRange(Directory.EnumerateFileSystemEntries(directory).ToList());
        }
        else
        {
            _printer.Print(indent + "\ud83d\udcc4" + new FileInfo(directory).Name);
        }

        if (_depth >= _maxDepth)
        {
            return;
        }

        foreach (string file in allFiles)
        {
            _depth += 1;
            Visit(file);
            _depth -= 1;
        }
    }
}