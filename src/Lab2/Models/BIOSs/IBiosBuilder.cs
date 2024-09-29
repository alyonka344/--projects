namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BIOSs;

public interface IBiosBuilder
{
    public IBiosBuilder WithType(string type);
    public IBiosBuilder WithVersion(string version);
    public IBiosBuilder AddSupportedProcessors(string cpu);
    public Bios Build();
}