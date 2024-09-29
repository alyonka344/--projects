namespace Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoriesVisitors;

#pragma warning disable CA1040
public interface IVisitor { }
#pragma warning restore CA1040

public interface IVisitor<T> : IVisitor
{
    void Visit(T directory);
}