using System;
using System.Linq;

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
        Console.ForegroundColor = ConsoleColor.Green;
        PrettyPrint(expression);
        Console.ForegroundColor = color;

        if (parser.Diagnostics.Any())
        {
          Console.ForegroundColor = ConsoleColor.Red;

          foreach (var diagnostic in parser.Diagnostics)
          {
            Console.WriteLine(diagnostic);
          
          }

          Console.ForegroundColor = color;
        }
      }
    }

    static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
    {
      var marker = isLast ? "└──" : "├──";

      Console.Write(indent);
      Console.Write(marker);
      Console.Write(node.Kind);

      if (node is SyntaxToken t && t.Value != null)
      {
        Console.Write(" ");
        Console.Write(t.Value);
      }

      Console.WriteLine();
      indent += isLast ? "    " : "│    ";

      var lastChild = node.GetChildren().LastOrDefault();

      foreach (var child in node.GetChildren())
      {
        PrettyPrint(child, indent, child == lastChild);
      }

    }
  }
}
