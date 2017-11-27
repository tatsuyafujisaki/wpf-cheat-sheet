using System;
using System.IO;
using WpfCheatSheet.Common;

namespace CheatSheet.Common
{
    sealed class TemporaryFile : IDisposable
    {
        readonly string _subdirectoryPath;
        internal readonly string Path1;

        internal TemporaryFile()
        {
            Path1 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            // The above does not create a file.
            // To create a file, use the following.
            // Path = System.IO.Path.GetTempFileName();
        }

        internal TemporaryFile(string fileName)
        {
            // Create a subdirectory in case the fileName exists and is locked.
            _subdirectoryPath = Path.Combine(Path.GetTempPath(), DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fffffff"));

            Directory.CreateDirectory(_subdirectoryPath);

            Path1 = Path.Combine(_subdirectoryPath, fileName);
        }

        public void Dispose()
        {
            if (Directory.Exists(_subdirectoryPath))
                Io.TryDeleteDirectory(_subdirectoryPath);
            else
                Io.TryDeleteFile(Path1);
        }
    }
}