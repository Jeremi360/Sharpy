using System;

namespace rc
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello User give me some math!");
      while (true)
      {
        Console.Write("> ");
        var line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
          return;
        }

        var parser = new Parser(line);
        var expression = parser.Parse();
        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        PrettyPrint(expression);
        Console.ForegroundColor = color;
      }
    }

    static void PrettyPrint(SyntaxNode node, string indent = "")
    {
      Console.Write(node.Kind);
      if (node is SyntaxToken t && t.Value != null)
      {
        Console.Write(" ");
        Console.Write(t.Value);
      }

      indent += "    ";
      foreach (var child in node.GetChildren())
      {
        PrettyPrint(child, indent);
      }

    }
  }
}
