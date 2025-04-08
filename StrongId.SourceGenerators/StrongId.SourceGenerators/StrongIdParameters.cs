namespace StrongId.SourceGenerators;

internal record StrongIdParameters(string ParameterType, string ParameterName)
{
    internal string ParameterType { get; set; } = ParameterType;
    internal string ParameterName { get; set; } = ParameterName;
}