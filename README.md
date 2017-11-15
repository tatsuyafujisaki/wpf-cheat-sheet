[![Build status](https://ci.appveyor.com/api/projects/status/l5tsskn518iijvus?svg=true)](https://ci.appveyor.com/project/tatsuya/wpf-cheat-sheet)

# Note
* ApplicationCommands cannot be used in MVVM.
* InputBinding.CommandParameter is not DependencyProperty so cannot pass a UI.
* Use Behavior to access KeyEventArgs or MouseEventArgs.
  * KeyBinding cannot access KeyEventArgs.
  * MouseBinding cannot access MouseEventArgs.
* How to make the UI thread wait until a non-UI thread is done.
```csharp
await Task.Run(() => IamNonUiThread());
```

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
Binding target|UI

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
