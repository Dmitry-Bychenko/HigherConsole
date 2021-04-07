using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherConsole {
  
  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static partial class ConsoleEnumerableExtensions {
    #region Public

    /// <summary>
    /// To Standard Output stream 
    /// </summary>
    public static void ToStdOutLines<T>(this IEnumerable<T> source) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      StdOut.WriteAllLines(source);
    }

    /// <summary>
    /// To Standard Error stream
    /// </summary>
    public static void ToStdErrLines<T>(this IEnumerable<T> source) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      StdErr.WriteAllLines(source);
    }

    /// <summary>
    /// To Both Standard Out and Errror
    /// </summary>
    public static void ToStdStreamLines<T>(this IEnumerable<T> source, 
                                                Func<T, bool> printInStdOut,
                                                Func<T, bool> printInStdErr) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      using var stdWriter = new StreamWriter(Console.OpenStandardOutput());
      using var errWriter = new StreamWriter(Console.OpenStandardOutput());

      bool stdFirst = true;
      bool errFirst = true;

      foreach (T item in source) {
        if (printInStdOut is not null && printInStdOut(item)) {
          if (!stdFirst)
            stdWriter.WriteLine();

          stdFirst = false;

          stdWriter.Write(item);
        }

        if (printInStdErr is not null && printInStdErr(item)) {
          if (!errFirst)
            errWriter.WriteLine();

          errFirst = false;

          errWriter.Write(item);
        }
      }
    }

    #endregion Public
  }

}
