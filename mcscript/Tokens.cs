
namespace mcscript
{
  public class Token
  {
    public TokenType type;
    public string value;

    public Token(TokenType type, string value)
    {
      this.type = type;
      this.value = value;
    }
  }

  public enum TokenType
  {
    None,
    // Keywords
    PRINT,

    // Operators

    MODULO,

    // Logic


    // Delimiters

    // Types
    STRING,

    // End of file
    EOF
  }
}