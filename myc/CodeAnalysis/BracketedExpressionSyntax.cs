using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mython.CodeAnalysis
{
  public class BracketedExpressionSyntax : ExpressionSyntax
  {
    public BracketedExpressionSyntax(SyntaxToken openBracketToken, ExpressionSyntax expression, SyntaxToken closeBracketToken)
    {
      OpenBracketToken = openBracketToken;
      Expression = expression;
      CloseBracketToken = closeBracketToken;
    }

    public SyntaxToken OpenBracketToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseBracketToken { get; }

    public override SyntaxKind Kind => SyntaxKind.BracketedExpression;

    public override IEnumerable<SyntaxNode> GetChildren()
    {
      yield return OpenBracketToken;
      yield return Expression;
      yield return CloseBracketToken;
    }
  }
}
