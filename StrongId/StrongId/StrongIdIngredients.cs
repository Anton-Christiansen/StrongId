using System.Collections.Generic;

namespace StrongId;

internal record StrongIdIngredients(string Namespace, List<string> Classes, string Class, StrongIdParameters Parameters)
{
    internal string Namespace { get; } = Namespace;
    internal List<string> Classes { get; } = Classes;
    internal string Class { get; set; } = Class;
    internal StrongIdParameters Parameters { get; } = Parameters;
}