using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public class SubRepository<T> : ISubRepository
{
    private readonly Dictionary<string, IComponent> _registeredComponent = new();

    public bool Register(IComponent element)
    {
        ArgumentNullException.ThrowIfNull(element);

        return _registeredComponent.TryAdd(element.Name, element);
    }

    public bool TryGetElement(string name, out IComponent? value)
    {
        bool result = _registeredComponent.TryGetValue(name, out IComponent? foundElement);
        value = foundElement;

        return result;
    }
}