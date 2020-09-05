using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using NetworkConfig.Services;
using NetworkConfig.DataTypes;
using NetworkConfig.Commands;

namespace NetworkConfig.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private readonly IRegistryService registryService;

        private ObservableCollection<VersionInformation> versions;

        private VersionInformation selectedVersion;

        private string sharedDirectory;

        private string newSharedDirectory;

        #endregion

        #region Construction

        public MainWindowViewModel(IRegistryService registryService)
        {
            this.registryService = registryService;

            BrowseForFolderCommand = new DelegateCommand(OnBrowseForFolderCommand);
            UpdateRegistryCommand = new DelegateCommand(OnUpdateRegistryCommand);

            Versions = registryService.GetVersions();
            if (Versions.Any())
            {
                SelectedVersion = Versions[0];
            }
            
        }

        #endregion

        #region Commands

        public ICommand BrowseForFolderCommand { get; }

        public ICommand UpdateRegistryCommand { get; }

        #endregion

        #region Public Properties
     
        public ObservableCollection<VersionInformation> Versions
        {
            get => this.versions;

            set
            {
                this.versions = value;
                OnPropertyChanged();
            }
        }

        public VersionInformation SelectedVersion
        {
            get => this.selectedVersion;

            set
            {
                this.selectedVersion = value;
                SharedDirectory = registryService.GetCurrentSharedDirectory(selectedVersion.RegistryKey);
                OnPropertyChanged();
            }
        }

        public string SharedDirectory
        {
            get => this.sharedDirectory;

            set
            {
                this.sharedDirectory = value;
                OnPropertyChanged();
            }
        }

        public string NewSharedDirectory
        {
            get => this.newSharedDirectory;

            set
            {
                this.newSharedDirectory = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Private Methods     

        private void OnBrowseForFolderCommand(object parameter)
        {

        }

        private void OnUpdateRegistryCommand(object parameter)
        {
            registryService.SetSharedDirectoryKey(selectedVersion.RegistryKey, NewSharedDirectory);
            SharedDirectory = registryService.GetCurrentSharedDirectory(selectedVersion.RegistryKey);
            NewSharedDirectory = string.Empty;
        }

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}

