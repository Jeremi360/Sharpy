using System;


namespace mcscript
{
  public class Expression
  {
    private Token token_a;
    private Token token_b;

    public Expression(Token token_a, Token token_b)
    {
      this.token_a = token_a;
      this.token_b = token_b;
    }
  }
}