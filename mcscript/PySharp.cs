using System;


namespace mcscript
{
  public static class PySharp
  {
    public static bool In<T>(this T str, params T[] arr)
    {
      return Array.IndexOf(arr, str) != -1;
    }
  }

}
