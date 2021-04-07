using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HigherConsole {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Standard Input Stream
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class StdIn {
    #region Public

    /// <summary>
    /// Read All Text
    /// </summary>
    public static string ReadAllText(Encoding encoding) {
      using var reader = new StreamReader(Console.OpenStandardInput(), encoding);

      return reader.ReadToEnd();
    }

    /// <summary>
    /// Read All Text
    /// </summary>
    public static string ReadAllText() {
      using var reader = new StreamReader(Console.OpenStandardInput());

      return reader.ReadToEnd();
    }

    /// <summary>
    /// Read lines 
    /// </summary>
    public static IEnumerable<string> ReadLines(Encoding encoding) {
      using var reader = new StreamReader(Console.OpenStandardInput(), encoding);

      for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
        yield return line;
    }

    /// <summary>
    /// Read lines 
    /// </summary>
    public static IEnumerable<string> ReadLines() {
      using var reader = new StreamReader(Console.OpenStandardInput());

      for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
        yield return line;
    }

    /// <summary>
    /// Read lines 
    /// </summary>
    public static string[] ReadAllLines(Encoding encoding) {
      using var reader = new StreamReader(Console.OpenStandardInput(), encoding);

      List<string> list = new();

      for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
        list.Add(line);

      return list.ToArray();
    }

    /// <summary>
    /// Read lines 
    /// </summary>
    public static string[] ReadAllLines() {
      using var reader = new StreamReader(Console.OpenStandardInput());

      List<string> list = new();

      for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
        list.Add(line);

      return list.ToArray();
    }

    #endregion Public
  }

}
