using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Models.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;

public class Route
{
    public Route(IReadOnlyCollection<Environment> environments)
    {
        Environments = environments;
    }

    public IReadOnlyCollection<Environment> Environments { get; }
}