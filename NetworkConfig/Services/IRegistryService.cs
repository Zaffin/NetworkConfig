using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetworkConfig.DataTypes;

namespace NetworkConfig.Services
{
    public interface IRegistryService
    {
        string GetCurrentSharedDirectory(string selectedVersionKey);

        ObservableCollection<VersionInformation> GetVersions();

        void SetSharedDirectoryKey(string selectedVersionKey, string updatedDirectory);

    }
}
