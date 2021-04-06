using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mython.CodeAnalysis
{
  public class SyntaxTree
  {
    public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken _EOFToken)
    {
      Diagnostics = diagnostics.ToArray();
      Root = root;
      EOFToken = _EOFToken;
    }

    public IReadOnlyList<string> Diagnostics { get; }
    public ExpressionSyntax Root { get; }
    public SyntaxToken EOFToken { get; }

    public static SyntaxTree Parse(string code)
    {
      var p = new Parser(code);
      return p.Parse();
    }

  }
}