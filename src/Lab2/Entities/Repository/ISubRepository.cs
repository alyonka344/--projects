using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public interface ISubRepository
{
    public bool Register(IComponent element);
    public bool TryGetElement(string name, out IComponent? value);
}