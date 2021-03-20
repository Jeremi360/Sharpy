using System;
using System.Collections.Generic;
using System.Linq;

namespace rc
{
  public class SyntaxToken : SyntaxNode
  {
    public SyntaxToken(SyntaxKind kind, int pos, string code, object value)
    {
      Kind = kind;
      Pos = pos;
      Code = code;
      Value = value;
    }

    public override SyntaxKind Kind { get; }

    public int Pos { get; }
    public string Code { get; }
    public object Value { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
      return Enumerable.Empty<SyntaxNode>();
    }
  }
}
