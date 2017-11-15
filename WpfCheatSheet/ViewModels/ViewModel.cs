using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfCheatSheet.Commands;
using WpfCheatSheet.Common;
using WpfCheatSheet.Messengers;
using WpfCheatSheet.Models;

namespace WpfCheatSheet.ViewModels
{
    class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            if (File.Exists(settingsFile))
            {
                using (var sw = new StreamReader(settingsFile))
                {
                    File1 = sw.ReadLine();
                    Folder1 = sw.ReadLine();
                }
            }

            Items = new List<Item> { new Item("Name1", false, "User1", DateTime.Now),
                                     new Item("Name2", false, "User2", DateTime.Now) };
        }

        const string settingsFile = "Settings.txt";

        public Messenger Messenger { get; set; } = new Messenger();

        public string WindowTitle
        {
            get => string.Concat("Title1 ", U.CreateBreadcrumb());
        }

        string folder1;
        public string Folder1
        {
            get => folder1;

            set
            {
                folder1 = value;
                NotifyPropertyChanged(nameof(Folder1));
                ErrorIfEmpty(nameof(Folder1), value);
            }
        }

        string file1;
        public string File1
        {
            get => file1;

            set
            {
                file1 = value;
                NotifyPropertyChanged(nameof(File1));
                ErrorIfEmpty(nameof(File1), value);
            }
        }

        public double DataGridMaxHeight
        {
            get => SystemParameters.VirtualScreenHeight * 0.5;
        }

        List<Item> items;
        public List<Item> Items
        {
            get => items;

            set
            {
                items = value;
                NotifyPropertyChanged(nameof(Items));
            }
        }

        Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem;

            set
            {
                selectedItem = value;
                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }

        ICommand dropCommand;
        public ICommand DropCommand
        {
            get
            {
                return dropCommand ?? (dropCommand = new DelegateCommand(e =>
                {
                    var paths = ((DragEventArgs)e).Data.GetData(DataFormats.FileDrop) as string[];

                    if (paths == null)
                    {
                        return;
                    }

                    foreach (var path in paths)
                    {
                        if (!Bool.EqIgnoreCase(Path.GetExtension(path), ".txt"))
                        {
                            Messenger.Send(new Message("Please drop a txt file."));
                            return;
                        }

                        var fileName = Path.GetFileName(path);

                        if (Items.Select(r => r.Name).Contains(fileName))
                        {
                            Messenger.Send(new Message(string.Format("The name \"{0}\" is already taken.", fileName)));
                            return;
                        }

                        // Upload and activate the txt file.
                    }
                }));
            }
        }

        ICommand openFolderCommand;
        public ICommand OpenFolderCommand
        {
            get
            {
                return openFolderCommand ?? (openFolderCommand = new DelegateCommand(e =>
                {
                    var path = Io.FolderBrowserDialog();

                    if (path == null)
                    {
                        return;
                    }

                    switch (e)
                    {
                        case nameof(Folder1):
                            Folder1 = path;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }));
            }
        }

        ICommand openFileCommand;
        public ICommand OpenFileCommand
        {
            get
            {
                return openFileCommand ?? (openFileCommand = new DelegateCommand(e =>
                {
                    var path = Io.OpenFileDialog();

                    if (path == null)
                    {
                        return;
                    }

                    switch (e)
                    {
                        case nameof(File1):
                            File1 = path;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }));
            }
        }

        ICommand saveSettingsCommand;
        public ICommand SaveSettingsCommand
        {
            get
            {
                return saveSettingsCommand ?? (saveSettingsCommand = new DelegateCommand(e =>
                {
                    using (var sw = new StreamWriter(settingsFile))
                    {
                        sw.WriteLine();
                        sw.WriteLine();
                    }
                }));
            }
        }
    }
}
