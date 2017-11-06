[![Build status](https://ci.appveyor.com/api/projects/status/l5tsskn518iijvus?svg=true)](https://ci.appveyor.com/project/tatsuya/wpf-cheat-sheet)

# Best practices
* Use {Binding Property1} rather than {Binding Path=Property1} as the keyword Path is optional.
* Omit Grid.Row="0" and Grid.Column="0" as they are optional.
* Use ListView rather than ListBox because ListView inherits ListBox, which means ListView is better.

# Links
[Binding Sources Overview](https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/binding-sources-overview)
