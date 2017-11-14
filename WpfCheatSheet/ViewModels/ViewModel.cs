using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WpfCheatSheet.Commands;
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
                Messenger.Send(new Message("Folder is set!"));

                folder1 = value;
                NotifyPropertyChanged(nameof(Folder1));
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
            }
        }

        public double DataGridMaxHeight
        {
            get => SystemParameters.VirtualScreenHeight * 0.5;
        }

        List<Item> item;
        public List<Item> Items
        {
            get => item;

            set
            {
                item = value;
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

        public ICommand CloseWindowCommand
        {
            get => new DelegateCommand(e => ((Window)((KeyEventArgs)e).Source).Close(), e => ((KeyEventArgs)e).Key == Key.Escape);
        }

        ICommand setFolderCommand;
        public ICommand SetFolderCommand
        {
            get
            {
                return setFolderCommand ?? (setFolderCommand = new DelegateCommand(e =>
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

        ICommand setFileCommand;
        public ICommand SetFileCommand
        {
            get
            {
                return setFileCommand ?? (setFileCommand = new DelegateCommand(e =>
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
