using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

using Ookii.Dialogs.Wpf;

namespace NetworkConfig.Services
{
    public class FileService : IFileService
    {
        public bool IsDirectoyOnDisk(string path)
        {
            return Directory.Exists(path);
        }

        public (bool isSuccess, string path) SelectFolder(string description)
        {
            var selectedFolderDialog = new VistaFolderBrowserDialog()
            {
                Description = description,
                UseDescriptionForTitle = true
            };

            return (bool)selectedFolderDialog.ShowDialog() ? (true, selectedFolderDialog.SelectedPath) : (false, string.Empty);
        }
    }
}
