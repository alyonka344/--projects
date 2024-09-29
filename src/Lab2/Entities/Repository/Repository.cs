using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public class Repository : IRepository
{
    private List<ISubRepository> _subRepositories = new();

    public bool Register<T>(T element)
    where T : IComponent
    {
        ISubRepository? subRepository = _subRepositories.FirstOrDefault(repository => repository is SubRepository<T>);
        if (subRepository is null)
        {
            _subRepositories.Add(new SubRepository<T>());
            subRepository = _subRepositories.Last();
        }

        return subRepository.Register(element);
    }

    public bool TryGetElement<T>(string name, out T? element)
    where T : IComponent
    {
        ISubRepository? subRepository = _subRepositories.FirstOrDefault(repository => repository is SubRepository<T>);
        if (subRepository is not null)
        {
            bool result = subRepository.TryGetElement(name, out IComponent? value);
            if (value is not null)
            {
                element = (T)value;
                return result;
            }
        }

        element = default;
        return false;
    }
}