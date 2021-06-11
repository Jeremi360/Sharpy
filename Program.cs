using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Myhton
{
  class Program
  {
    static void Main(string[] args)
    {

      ParseMethod();

    }

    public static void ParseMethod()
    {
      String input = "your text to parse here";
      ICharStream stream = CharStreams.fromString(input);
      ITokenSource lexer = new HelloLexer(stream);
      ITokenStream tokens = new CommonTokenStream(lexer);
      HelloParser parser = new HelloParser(tokens);
      parser.BuildParseTree = true;
      IParseTree tree = parser.StartRule();
    }
  }
}
