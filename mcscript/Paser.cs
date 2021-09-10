using System;
using System.Collections.Generic;

namespace mcscript
{
  public class Parser
  {

    public static void Parse(List<Token> tokens)
    {
      bool continue_parsing = false;
      string token_a = "";
      string token_b = "";
      foreach (var token in tokens)
      {
        // check if token is a keyword
        if (token.type.In(
          TokenType.PRINT
        ))
        {
          token_a = token.value;
          continue_parsing = true;
        }

        if (continue_parsing)
        {
          token_b = token.value;
          continue_parsing = false;
        }
      }

    }
  }

}

