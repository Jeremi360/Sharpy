namespace Mython.CodeAnalysis
{
  public enum SyntaxKind
  {
    NumberToken,
    SpaceToken,
    PlusToken,
    MinusToken,
    MultToken,
    DivToken,
    OpenBracketToken,
    CloseBracketToken,
    BadToken,

    /// <summary>
    /// End of File
    /// </summary>
    EOFToken,
    NumberExpression,
    BinaryExpression,
    BracketedExpression
  }
}
