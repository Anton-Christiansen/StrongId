using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StrongId.SourceGenerators;

internal class StrongIdSyntaxReceiver : ISyntaxReceiver
{
    internal List<StrongIdIngredients> Ingredients { get; } = [];
    
    
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not FileScopedNamespaceDeclarationSyntax namespaceDeclaration) return;
        
        
        var visitor = new StrongIdSyntaxWalker();
        namespaceDeclaration.Accept(visitor);
            
        Ingredients.AddRange(visitor.Ingredients);
    }
}