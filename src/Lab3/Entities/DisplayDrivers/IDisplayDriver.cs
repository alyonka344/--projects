using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public interface IDisplayDriver
{
    public Color Color { get; set; }
    public string Message { get; set; }
    public void ClearOutput();
}