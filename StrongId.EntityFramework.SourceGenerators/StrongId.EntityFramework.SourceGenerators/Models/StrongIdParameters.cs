namespace StrongId.EntityFramework.SourceGenerators.Models;

internal record StrongIdParameters(string ParameterType, string ParameterName)
{
    internal string ParameterType { get; } = ParameterType;
    internal string ParameterName { get; } = ParameterName;
}