# Higher Console

this library contains several console UI routines

## Some Examples

```c#
using HigherConsole;

...

Console.WriteLine("Plain line # 1");

using (ConsoleAppearance.Red()) {
  Console.WriteLine("Something very wrong");
}

Console.WriteLine("Plain line # 1");
```
