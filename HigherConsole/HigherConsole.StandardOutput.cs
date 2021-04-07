using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HigherConsole {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Standard Output stream
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class StdOut {
    #region Public 

    /// <summary>
    /// Write All Lines
    /// </summary>
    public static IEnumerable<T> WriteAllLines<T>(IEnumerable<T> source, Encoding encoding) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      using var writer = new StreamWriter(Console.OpenStandardOutput(), encoding);

      bool first = true;

      foreach (T item in source) {
        if (first)
          first = false;
        else
          writer.WriteLine();

        writer.Write(item);

        yield return item;
      }
    }

    /// <summary>
    /// Write All Lines
    /// </summary>
    public static IEnumerable<T> WriteAllLines<T>(IEnumerable<T> source) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      using var writer = new StreamWriter(Console.OpenStandardOutput());

      bool first = true;

      foreach (T item in source) {
        if (first)
          first = false;
        else
          writer.WriteLine();

        writer.Write(item);

        yield return item;
      }
    }

    /// <summary>
    /// Write All Text
    /// </summary>
    public static void WriteAllText(string text, Encoding encoding) {
      if (string.IsNullOrEmpty(text))
        return;

      using var writer = new StreamWriter(Console.OpenStandardOutput(), encoding);

      writer.Write(text);
    }

    /// <summary>
    /// Write All Text
    /// </summary>
    public static void WriteAllText(string text) {
      if (string.IsNullOrEmpty(text))
        return;

      using var writer = new StreamWriter(Console.OpenStandardOutput());

      writer.Write(text);
    }

    #endregion Public
  }

}
