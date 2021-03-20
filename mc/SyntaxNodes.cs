using System;
using System.Collections;
using System.Collections.Generic;

namespace rc
{
  public abstract class SyntaxNode
  {
    public abstract SyntaxKind Kind { get; }

    public abstract IEnumerable<SyntaxNode> GetChildren();
  }

  public abstract class ExpressionSyntax : SyntaxNode
  {
  }

  public sealed class NumberExpressionSyntax : ExpressionSyntax
  {
    public NumberExpressionSyntax(SyntaxToken numberToken)
    {
      NumberToken = numberToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NumberExpression;
    public SyntaxToken NumberToken { get; }
  }

  public sealed class BinaryExpressionSyntax : ExpressionSyntax
  {
    public BinaryExpressionSyntax(ExpressionSyntax left,
      SyntaxToken operatorToken, ExpressionSyntax right)
    {
      Left = left;
      OperatorToken = operatorToken;
      Right = right;
    }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
    public ExpressionSyntax Left { get; }
    public SyntaxToken OperatorToken { get; }
    public ExpressionSyntax Right { get; }
  }
}
