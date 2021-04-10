# Higher Console

[![NuGet version (HigherConsole)](https://img.shields.io/nuget/v/HigherConsole.svg?style=flat-square)](https://www.nuget.org/packages/HigherConsole/)

this library contains several console UI routines

## Some Examples

### Red and grey lines:

```c#
using HigherConsole;

...

Console.WriteLine("Plain line # 1");

using (ConsoleAppearance.Red()) {
  Console.WriteLine("Something very wrong");
}

Console.WriteLine("Plain line # 1");
```

### Linq like example

```c#
using HigherConsole;

...

StdIn
  .ReadLines()
  .Where(line => !string.IsNullOrWhiteSpace(line))
  .Skip(1)
  .Select(line => int.Parse(line))
  .Select(x => x * x)
  .ToStdOutLines();
```
