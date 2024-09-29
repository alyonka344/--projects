using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public interface IRepository
{
    public bool Register<T>(T element)
        where T : IComponent;
    public bool TryGetElement<T>(string name, out T? element)
        where T : IComponent;
}