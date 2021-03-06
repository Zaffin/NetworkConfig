﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;

using NetworkConfig.DataTypes;
using NetworkConfig.Properties;
using NetworkConfig.Resources;

namespace NetworkConfig.Services
{
    public class RegistryService : IRegistryService
    {
        public string GetCurrentSharedDirectory(string selectedVersionKey)
        {
            return (string)Registry.GetValue(selectedVersionKey, "SharedDir", null);
        }

        public ObservableCollection<VersionInformation> GetVersions()
        {
            var versions = new ObservableCollection<VersionInformation>();

            var subKeys = Registry.CurrentUser.OpenSubKey(Settings.Default.VersionSubKey);

            if (subKeys == null)
            {
                MessageBox.Show(UIResources.MastercamNotInstalledError, UIResources.ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return versions;
            }

            var regexPattern = Settings.Default.VersionRegex;

            foreach (var subKeyName in subKeys.GetSubKeyNames())
            {
                if (Regex.IsMatch(subKeyName, regexPattern))
                {
                    versions.Add(new VersionInformation()
                    {
                        Description = subKeyName,
                        RegistryKey = subKeys.Name + "\\" + subKeyName
                    });
                }
            }

            return versions;
        }

        public void SetSharedDirectoryKey(string selectedVersionKey, string updatedDirectory)
        {
            try
            {
                Registry.SetValue(selectedVersionKey, "SharedDir", updatedDirectory);
            }
            catch (Exception ex)
            {

                var error = $"{ex.Message}\n" +
                            $"{ex.InnerException?.Message}";

                MessageBox.Show(error, UIResources.ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
