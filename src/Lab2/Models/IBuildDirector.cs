namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IBuildDirector<T>
{
    public T Direct(T builder);
}