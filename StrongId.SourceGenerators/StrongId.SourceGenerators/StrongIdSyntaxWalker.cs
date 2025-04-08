using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StrongId.SourceGenerators;


/// <summary>
/// It will walk down from "FileScopedNamespaceDeclarationSyntax" (namespace)
/// into "ClassDeclarationSyntax" (class)
/// into "AttributeSyntax" (the attribute)
/// And then follow the tree down for any nested classes
/// It will store the namespace, and the outer classes, and the marked class
/// </summary>
internal class StrongIdSyntaxWalker : CSharpSyntaxWalker
{
    internal List<StrongIdIngredients> Ingredients { get; } = [];
    
    private FileScopedNamespaceDeclarationSyntax? _currentNamespace;
    private readonly List<ClassDeclarationSyntax> _classDeclarations = [];
    private ClassDeclarationSyntax? _currentClass;


    public override void VisitAttribute(AttributeSyntax attribute)
    {
        if (attribute.Name.ToFullString() == "StrongId")
        {
            var parameters = GetAttributeParameters(attribute);
            Ingredients.Add(new StrongIdIngredients(
                _currentNamespace!.Name.ToString(), 
                    _classDeclarations.Select(x => x.Identifier.Text).ToList(), 
                    _currentClass!.Identifier.Text, parameters));
        }
        
        base.VisitAttribute(attribute);
    }


    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        if (_currentClass != null)
        {
            _classDeclarations.Add(_currentClass);
        }
        _currentClass = node;
        
        
        base.VisitClassDeclaration(node);
        
        
        _currentClass = _classDeclarations.Count > 0 
            ? _classDeclarations.Last() 
            : null;

    }

    public override void VisitFileScopedNamespaceDeclaration(FileScopedNamespaceDeclarationSyntax node)
    {
        _currentNamespace = node;
        base.VisitFileScopedNamespaceDeclaration(node);
        _currentNamespace = null;
    }
    
    private static StrongIdParameters GetAttributeParameters(AttributeSyntax attribute)
    {
        string parametertype = typeof(Guid).ToString();
        string parameterName = "Id";
        
        var arguments = attribute.ArgumentList?.Arguments ?? [];
        foreach (var syntax in arguments)
        {
            var parameter = syntax.NameEquals?.Name.ToString() ?? string.Empty;
            
            switch (parameter)
            {
                case "ParameterType":
                {
                    var expression = syntax.Expression.ToString();
                    parametertype = expression.Trim().Substring(7, expression.Length - 8);
                    break;
                }

                case "ParameterName":
                {
                    parameterName = syntax.Expression.ToString().Trim('"');
                    break;
                }
            }
        }
        
        return new StrongIdParameters(parametertype, parameterName);
    }
    
    
}