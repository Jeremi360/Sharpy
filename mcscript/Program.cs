using System;


namespace mcscript
{
  class Program
  {
    static void Main(string[] args)
    {
      var test_code = "print \"some text\"";

      var lexer = new Lexer(test_code);
      var tokens = lexer.Tokenize();

      foreach (var token in tokens)
      {
        Console.WriteLine(token);
      }

      Console.WriteLine("\n\n");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();

    }
  }
}
