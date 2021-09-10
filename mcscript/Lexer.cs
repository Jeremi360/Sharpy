using System;
using System.Collections.Generic;

namespace mcscript
{
  class Lexer
  {
    private string code;
    public Lexer(string code)
    {
      this.code = code;
    }

    public List<Token> Tokenize()
    {
      var tokens = new List<Token>();
      var token_value = "";
      var token_type = TokenType.None;

      foreach (var c in code)
      {
        if (c != ' ')
        {
          token_value += c;
        }
        else
        {
          if (token_value != "")
          {
            token_type = GetTokenType(token_value);
            tokens.Add(new Token(token_type, token_value));
          }
        }

      }
      return tokens;
    }

    TokenType GetTokenType(string token_value)
    {
      switch (token_value)
      {
        case "print":
          return TokenType.PRINT;
      }

      if (token_value.StartsWith("\""))
      {
        return TokenType.STRING;
      }

      return TokenType.None;
    }

  }
}
