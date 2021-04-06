using System;
using System.Collections.Generic;
using System.Linq;
using Minsk.Helper;

namespace Minsk.CodeAnalysis
{
  public class Parser
  {
    private readonly SyntaxToken[] _tokens;
    private int _pos;

    private List<string> _diagnostics = new();
    public IEnumerable<string> Diagnostics => _diagnostics;

    public Parser(string code)
    {
      var tokens = new List<SyntaxToken>();
      var lexer = new Lexer(code);
      SyntaxToken token;
      do
      {
        token = lexer.NextToken();
        if (token.Kind != SyntaxKind.SpaceToken
        && token.Kind != SyntaxKind.BadToken)
        {
          tokens.Add(token);
        }

      }
      while (token.Kind != SyntaxKind.EOFToken);
      _tokens = tokens.ToArray();
      _diagnostics.AddRange(lexer.Diagnostics);
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

      _diagnostics.Add($"Error: Unexpected Token {Current.Pos} : {Current.Value} -> {Current.Kind} , expected: {kind}");
      return new SyntaxToken(kind, Current.Pos, null, null);
    }

    public SyntaxTree Parse()
    {
      var expression = ParseTerm();
      var endOfFileToken = Match(SyntaxKind.EOFToken);

      return new SyntaxTree(Diagnostics, expression, endOfFileToken);
    }

    private ExpressionSyntax ParseTerm()
    {
      var left = ParseFactor();

      while (Current.Kind.In(
        SyntaxKind.PlusToken, SyntaxKind.MinusToken
        ))
      {
        var operatorToken = NextToken();
        var right = ParseFactor();
        left = new BinaryExpressionSyntax(left, operatorToken, right);

      }

      return left;
    }

    private ExpressionSyntax ParseFactor()
    {
      var left = ParsePrimaryExperssion();

      while (Current.Kind.In(
        SyntaxKind.DivToken, SyntaxKind.MultToken
        ))
      {
        var operatorToken = NextToken();
        var right = ParsePrimaryExperssion();
        left = new BinaryExpressionSyntax(left, operatorToken, right);

      }

      return left;
    }

    private ExpressionSyntax ParsePrimaryExperssion()
    {
      if (Current.Kind == SyntaxKind.OpenParenthesisToken)
      {
        var left = NextToken();
        var expression = ParseTerm();
        var right = Match(SyntaxKind.CloseParenthesisToken);
        return new ParenthesizedExpressionSyntax(left, expression, right);
      }

      var NumberToken = Match(SyntaxKind.NumberToken);
      return new NumberExpressionSyntax(NumberToken);
    }
  }
}