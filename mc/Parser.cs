using System;
using System.Collections.Generic;
using System.Linq;

namespace rc
{
  public class Parser
  {
    private readonly SyntaxToken[] _tokens;
    private int _pos;

    public Parser(string code)
    {
      var tokens = new List<SyntaxToken>();
      var lexer = new Lexer(code);
      SyntaxToken token;
      do
      {
        token = lexer.NextToken();
        if (token.Kind != SyntaxKind.SpaceToken
        || token.Kind != SyntaxKind.BadToken)
        {
          tokens.Add(token);
        }

      }
      while (token.Kind != SyntaxKind.EOFToken);
      _tokens = tokens.ToArray();
    }

    private SyntaxToken LookAhead(int offset)
    {
      int index = _pos + offset;
      if (index >= _tokens.Length)
      {
        return _tokens.Last();
      }

      return _tokens[index];
    }

    private SyntaxToken Current => LookAhead(0);

    private SyntaxToken NextToken()
    {
      var current = Current;
      _pos++;
      return current;
    }

    private SyntaxToken Match(SyntaxKind kind)
    {
      if (Current.Kind == kind)
      {
        return NextToken();
      }

      return new SyntaxToken(kind, Current.Pos, null, null);
    }

    public ExpressionSyntax Parse()
    {
      var left = ParsePrimaryExperssion();

      while (Current.Kind == SyntaxKind.PlusToken
      || Current.Kind == SyntaxKind.MinusToken)
      {
        var operatorToken = NextToken();
        var right = ParsePrimaryExperssion();
        left = new BinaryExpressionSyntax(left, operatorToken, right);

      }

      return left;
    }

    private ExpressionSyntax ParsePrimaryExperssion()
    {
      var NumberToken = Match(SyntaxKind.NumberToken);
      return new NumberExpressionSyntax(NumberToken);
    }
  }
}