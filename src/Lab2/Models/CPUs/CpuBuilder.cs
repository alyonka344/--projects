using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.CPUs;

public class CpuBuilder : ICpuBuilder
{
    private string? _name;
    private int? _coreFrequency;
    private int? _coreNumber;
    private string? _socket;
    private VideoCore? _videoCore;
    private List<int> _memoryFrequencies = new();
    private int? _heatGeneration;
    private int? _powerConsumption;

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreNumber(int coreNumber)
    {
        _coreNumber = coreNumber;
        return this;
    }

    public ICpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithVideoCore(VideoCore videoCore)
    {
        _videoCore = videoCore;
        return this;
    }

    public ICpuBuilder AddMemoryFrequency(int memoryFrequency)
    {
        _memoryFrequencies.Add(memoryFrequency);
        return this;
    }

    public ICpuBuilder WithHeatGeneration(int heatGeneration)
    {
        _heatGeneration = heatGeneration;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name,
            _coreFrequency,
            _coreNumber,
            _socket,
            _videoCore,
            _memoryFrequencies,
            _heatGeneration,
            _powerConsumption);
    }
}