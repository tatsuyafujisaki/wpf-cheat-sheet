[![Build status](https://ci.appveyor.com/api/projects/status/l5tsskn518iijvus?svg=true)](https://ci.appveyor.com/project/tatsuya/wpf-cheat-sheet)

###### Best practices
* Avoid specifying Grid.Row="0" or Grid.Column="0" as they are optional.
* Use ListView rather than ListBox because ListView inherits ListBox, which means ListView is better.
