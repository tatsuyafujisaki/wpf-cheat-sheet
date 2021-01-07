# Note
* `ApplicationCommands` cannot be used in MVVM.
* `InputBinding.CommandParameter` is not `DependencyProperty` so cannot pass a UI.
* Use `Behavior` to access `KeyEventArgs` or `MouseEventArgs`.
  * `KeyBinding` cannot access `KeyEventArgs`.
  * `MouseBinding` cannot access `MouseEventArgs`.
* `DataTemplate` is how to display an object in GUI and analogous to `ToString()` in CLI.
* How to make the UI thread wait until a non-UI thread is done.
```csharp
await Task.Run(() => IamNonUiThread());
```

# Best practices
* Omit `Grid.Row="0"` and `Grid.Column="0"` as they are default.
* Omit `Width="*"` on `ColumnDefinition` and `Height="*"` on `RowDefinition` as star is default.
* A rather than B
  * Use `{Binding Property1}` rather than `{Binding Path=Property1}` as `Path=` is optional.
  * Use attribute syntax rather than property element syntax
    * For example, use `<Button Content="Content1" />` rather than `<Button>Content1\<Button/>`
* Bind the following method to `PreviewMouseLeftButtonDown` rather than `MouseLeftButtonDown`. `MouseLeftButtonDown` is never called.
```csharp
void CheckIfNewVersionAvailable(object sender, MouseButtonEventArgs e)
{
    if (IsLatestVersion(...))
    {
        return;
    }

    if (MessageBox.Show("New version is available. Restart?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
    {
        // Start the new version and close self.
    }

    // Not relay to the Click event.
    e.Handled = true;
}
```

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

# References
* [Binding Sources Overview](https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/binding-sources-overview)
* [Binding Mode Enum](https://docs.microsoft.com/en-us/dotnet/api/system.windows.data.bindingmode)
