namespace Minsk.CodeAnalysis
{
  public enum SyntaxKind
  {
    NumberToken,
    SpaceToken,
    PlusToken,
    MinusToken,
    MultToken,
    DivToken,
    OpenParenthesisToken,
    CloseParenthesisToken,
    BadToken,

    /// <summary>
    /// End of File
    /// </summary>
    EOFToken,
    NumberExpression,
    BinaryExpression,
    ParenthesizedExpression
  }
}
