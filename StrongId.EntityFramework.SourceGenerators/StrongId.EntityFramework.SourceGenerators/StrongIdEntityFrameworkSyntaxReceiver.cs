using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StrongId.EntityFramework.SourceGenerators.Models;

namespace StrongId.EntityFramework.SourceGenerators;



internal class StrongIdEntityFrameworkSyntaxReceiver : ISyntaxReceiver
{
    internal List<StrongIdIngredients> Ingredients { get; } = [];
    
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        
        if (syntaxNode is not FileScopedNamespaceDeclarationSyntax namespaceDeclaration) return;
        
        
        var visitor = new StrongIdEntityFrameworkSyntaxWalker();
        namespaceDeclaration.Accept(visitor);
            
        Ingredients.AddRange(visitor.Ingredients);
    }
}