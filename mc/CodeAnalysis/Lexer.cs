using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Minsk.CodeAnalysis
{
  public class Lexer
  {
    private int _pos;
    private List<string> _diagnostics = new();
    public IEnumerable<string> Diagnostics => _diagnostics;
    public Lexer(string code)
    {
      Code = code;
    }

    private char Current
    {
      get
      {
        if (_pos >= Code.Length)
        {
          return '\0';
        }

        return Code[_pos];
      }
    }

    public string Code { get; }

    private void Next()
    {
      _pos++;
    }

    public SyntaxToken NextToken()
    {
      //<numbers>
      // + - * / ( )
      // <whitespace>

      if (_pos >= Code.Length)
      {
        return new SyntaxToken(SyntaxKind.EOFToken, _pos, "\0", null);
      }

      if (char.IsDigit(Current))
      {
        int start = _pos;
        while (char.IsDigit(Current))
        {
          Next();
        }

        int length = _pos - start;
        var code = Code.Substring(start, length);

        if (!int.TryParse(code, out var value))
        {
          _diagnostics.Add($"A number {code} isn't valid Int");
        }

        return new SyntaxToken(SyntaxKind.NumberToken, start, code, value);
      }

      if (char.IsWhiteSpace(Current))
      {
        int start = _pos;
        while (char.IsWhiteSpace(Current))
        {
          Next();
        }

        int length = _pos - start;
        var code = Code.Substring(start, length);
        // todo maybe change it for my langue
        return new SyntaxToken(SyntaxKind.SpaceToken, start, code, null);

      }

      switch (Current)
      {
        case '+':
          return new SyntaxToken(SyntaxKind.PlusToken, _pos++, "+", null);

        case '-':
          return new SyntaxToken(SyntaxKind.MinusToken, _pos++, "-", null);

        case '*':
          return new SyntaxToken(SyntaxKind.MultToken, _pos++, "*", null);

        case '/':
          return new SyntaxToken(SyntaxKind.DivToken, _pos++, "/", null);

        case '(':
          return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _pos++, "(", null);

        case ')':
          return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _pos++, ")", null);
      }

      _diagnostics.Add($"Error: Unexpected Input {_pos} : {Current}");
      return new SyntaxToken(SyntaxKind.BadToken, _pos++, Code.Substring(_pos - 1, 1), null);

    }
  }
}