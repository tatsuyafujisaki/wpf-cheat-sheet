[![Build status](https://ci.appveyor.com/api/projects/status/l5tsskn518iijvus?svg=true)](https://ci.appveyor.com/project/tatsuya/wpf-cheat-sheet)

# Note
* MouseBinding cannot access MouseEventArgs. Use Behavior to access MouseEventArgs.

# Best practices
* Omit Grid.Row="0" and Grid.Column="0" as they are optional.
* A rather than B
  * Use {Binding Property1} rather than {Binding Path=Property1} as "Path=" is optional.
  * Use attribute syntax rather than property element syntax
    * For example, use \<Button Content="Content1" /> rather than \<Button>Content1\<Button/>

# Glossary
Name|Description
---|---
Binding source|object
Binding target|GUI

# How to bind with self
```xml
"{Binding RelativeSource={RelativeSource Self}}"
```

# How to bind with another UI
```xml
<TextBox Name="TextBox1" />
<TextBox Name="TextBox2" Text="{Binding ElementName=TextBox1, Path=Text}" />
```

# Links
* [Binding Sources Overview](https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/binding-sources-overview)
* [Binding Mode Enum](https://docs.microsoft.com/en-us/dotnet/api/system.windows.data.bindingmode)
