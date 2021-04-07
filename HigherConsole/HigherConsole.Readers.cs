using System;
using System.Text;

namespace HigherConsole {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Console Readers 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static partial class ConsoleReader {
    #region Public

    /// <summary>
    /// Read string as password (masked)
    /// </summary>
    /// <param name="mask">mask to use</param>
    public static string ReadPasswordLine(char mask) {
      if (mask == '\0')
        return Console.ReadLine();

      StringBuilder sb = new();

      int position = Console.CursorLeft;
      int was = 0;

      while (true) {
        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Enter)
          return sb.ToString();
        else if (key.Key == ConsoleKey.Escape) {
          Console.CursorLeft = position;
          Console.Write(new string(' ', was));
          Console.CursorLeft = position;

          return "";
        }
        else if (key.Key == ConsoleKey.Backspace) {
          if (sb.Length > 0)
            sb.Length -= 1;
        }
        else if (key.KeyChar >= ' ')
          sb.Append(key.KeyChar);

        Console.CursorLeft = position;

        Console.Write(new string(' ', was));
        Console.CursorLeft = position;
        Console.Write(new string(mask, sb.Length));

        was = sb.Length;
      }
    }

    /// <summary>
    /// Read string as password (masked)
    /// </summary>
    public static string ReadPasswordLine() => ReadPasswordLine('*');

    /// <summary>
    /// Universal read
    /// </summary>
    /// <param name="title">Title, if any</param>
    /// <param name="validator">Validator</param>
    /// <returns>Value read</returns>
    /// <example>
    /// <code>
    /// int count = ConsoleReader.Read("Count", s => int.TryParse(s, out int i) ? (i, null) : (0, "Syntax error"));
    /// </code>
    /// </example>
    public static T Read<T>(string title, Func<string, (T value, string error)> validator) {
      if (validator is null)
        throw new ArgumentNullException(nameof(validator));

      while (true) {
        if (!string.IsNullOrWhiteSpace(title))
          Console.WriteLine(title);

        var (v, e) = validator(Console.ReadLine());

        if (string.IsNullOrWhiteSpace(e))
          return v;

        Console.WriteLine(e);
      }
    }

    #endregion Public
  }

}
