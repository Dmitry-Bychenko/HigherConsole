# Higher Console

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
