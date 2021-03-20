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

        var lexer = new Lexer(line);
        while (true)
        {
          var token = lexer.NextToken();
          if (token.Kind == SyntaxKind.EOFToken)
          {
            break;
          }
          Console.Write($"{token.Kind}: '{token.Code}'");
          if (token.Value != null)
          {
            Console.Write($" {token.Value}");
          }
          Console.WriteLine();
        }

      }
    }
  }
}
