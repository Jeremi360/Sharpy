using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mython.Helper
{
  public static class Helper
  {
    public static bool In<T>(this T o, params T[] list)
    {
      return list.Contains(o);
    }
  }
}