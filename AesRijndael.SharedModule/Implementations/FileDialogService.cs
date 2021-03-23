using System;

using AesRijndael.Core;

using Microsoft.Win32;

namespace AesRijndael.SharedModule
{
    public class FileDialogService : IFileDialogService
    {
        public string OpenFileDialog(string defaultExt)
        {
            if (string.IsNullOrEmpty(defaultExt))
                throw new ArgumentNullException(nameof(defaultExt));

            OpenFileDialog dialog = new()
            {
                DefaultExt = defaultExt,
                Multiselect = false
            };
            return dialog.FileName;
        }

        public string[] OpenFilesDialog(string defaultExt)
        {
            if (string.IsNullOrEmpty(defaultExt))
                throw new ArgumentNullException(nameof(defaultExt));

            OpenFileDialog dialog = new()
            {
                DefaultExt = defaultExt,
                Multiselect = false
            };
            return dialog.FileNames;
        }
    }
}
