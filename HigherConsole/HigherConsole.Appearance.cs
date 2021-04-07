using System;
using System.Runtime.Serialization;

namespace HigherConsole {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Console Appearance
  /// </summary>
  /// <example>
  /// <code>
  /// using (new ConsoleAppearance() {ForegroundColor = ConsoleColor.Red}) {
  ///   Console.WriteLine("Warning (RED alert)!");
  /// }
  /// </code>
  /// </example>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class ConsoleAppearance
    : IDisposable,
      IEquatable<ConsoleAppearance>,
      ISerializable {

    #region Private Data

    private readonly ConsoleColor m_SavedBackgroundColor;
    private readonly ConsoleColor m_SavedForegroundColor;

    #endregion Private Data

    #region Create

    // Deserialization
    private ConsoleAppearance(SerializationInfo info, StreamingContext context) {
      if (info is null)
        throw new ArgumentNullException(nameof(info));

      m_SavedBackgroundColor = Console.BackgroundColor;
      m_SavedForegroundColor = Console.ForegroundColor;

      Console.BackgroundColor = (ConsoleColor)(info.GetInt32("back"));
      Console.ForegroundColor = (ConsoleColor)(info.GetInt32("fore"));

      BackgroundColor = Console.BackgroundColor;
      ForegroundColor = Console.ForegroundColor;
    }

    /// <summary>
    /// Standard constructor
    /// </summary>
    public ConsoleAppearance(ConsoleColor foregroundColor, ConsoleColor backgroundColor) {
      m_SavedBackgroundColor = Console.BackgroundColor;
      m_SavedForegroundColor = Console.ForegroundColor;

      Console.BackgroundColor = backgroundColor;
      Console.ForegroundColor = foregroundColor;

      BackgroundColor = Console.BackgroundColor;
      ForegroundColor = Console.ForegroundColor;
    }

    /// <summary>
    /// Standard constructor
    /// </summary>
    public ConsoleAppearance(ConsoleColor foregroundColor)
      : this(foregroundColor, Console.BackgroundColor) { }

    /// <summary>
    /// Red foreground
    /// </summary>
    public static ConsoleAppearance Red() => new(ConsoleColor.Red);

    /// <summary>
    /// Yellow foreground
    /// </summary>
    public static ConsoleAppearance Yellow() => new(ConsoleColor.Yellow);

    /// <summary>
    /// Green foreground
    /// </summary>
    public static ConsoleAppearance Green() => new(ConsoleColor.Green);

    #endregion Create

    #region Public

    /// <summary>
    /// Background Color
    /// </summary>
    public ConsoleColor BackgroundColor { get; }

    /// <summary>
    /// Foreground Color
    /// </summary>
    public ConsoleColor ForegroundColor { get; }

    /// <summary>
    /// To String (debug)
    /// </summary>
    public override string ToString() =>
      $"{ForegroundColor} on {BackgroundColor}";

    #endregion Public

    #region IDisposable

    /// <summary>
    /// If instance disposed
    /// </summary>
    public bool IsDisposed { get; private set; } = false;

    private void Dispose(bool disposing) {
      if (IsDisposed)
        return;

      IsDisposed = true;

      if (disposing) {
        if (Console.BackgroundColor == BackgroundColor)
          Console.BackgroundColor = m_SavedBackgroundColor;

        if (Console.ForegroundColor == ForegroundColor)
          Console.ForegroundColor = m_SavedForegroundColor;
      }
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose() => Dispose(true);

    #endregion IDisposable

    #region IEquatable<ConsoleAppearance>

    /// <summary>
    /// Equals 
    /// </summary>
    public bool Equals(ConsoleAppearance other) {
      if (other is null)
        return false;

      return BackgroundColor == other.BackgroundColor &&
             ForegroundColor == other.ForegroundColor;
    }

    /// <summary>
    /// Equals
    /// </summary>
    public override bool Equals(object obj) => obj is ConsoleAppearance other && Equals(other);

    /// <summary>
    /// Hash Code
    /// </summary>
    public override int GetHashCode() {
      unchecked {
        return (((int)ForegroundColor) << 16) | (int)BackgroundColor;
      }
    }

    #endregion IEquatable<ConsoleAppearance>

    #region ISerializable

    /// <summary>
    /// Serialization
    /// </summary>
    public void GetObjectData(SerializationInfo info, StreamingContext context) {
      if (info is null)
        throw new ArgumentNullException(nameof(info));

      info.AddValue("back", (int)BackgroundColor);
      info.AddValue("fore", (int)ForegroundColor);
    }

    #endregion ISerializable
  }

}
