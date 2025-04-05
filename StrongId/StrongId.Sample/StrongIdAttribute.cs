using System;

namespace StrongId.Sample;

[AttributeUsage(AttributeTargets.Class)]
public class StrongIdAttribute : Attribute
{
    public Type ParameterType { get; set; } = typeof(Guid);
    public string ParameterName { get; set; } = "Id";
}
