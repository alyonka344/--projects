namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CPUs;

public interface ICpuBuilder
{
    public ICpuBuilder WithName(string name);
    public ICpuBuilder WithCoreFrequency(int coreFrequency);
    public ICpuBuilder WithCoreNumber(int coreNumber);
    public ICpuBuilder WithSocket(string socket);
    public ICpuBuilder WithVideoCore(VideoCore videoCore);
    public ICpuBuilder AddMemoryFrequency(int memoryFrequency);
    public ICpuBuilder WithHeatGeneration(int heatGeneration);
    public ICpuBuilder WithPowerConsumption(int powerConsumption);
    public Cpu Build();
}