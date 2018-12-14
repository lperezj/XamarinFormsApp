using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Messaging;
    using GalaSoft.MvvmLight.Views;

    using Xamarin.Essentials;

    public class DeviceInfoPageViewModel : ViewModelBase
    {
        private string currentDeviceInfoName;

        private string currentDeviceInfoManufacturer;

        private string currentDeviceInfoVersion;

        /// <summary>
        /// Gets or sets the current device info.
        /// </summary>
        public string CurrentDeviceInfoName
        {
            get => this.currentDeviceInfoName;

            set
            {
                this.currentDeviceInfoName = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the current device info.
        /// </summary>
        public string CurrentDeviceInfoManufacturer
        {
            get => this.currentDeviceInfoManufacturer;

            set
            {
                this.currentDeviceInfoManufacturer = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the current device info.
        /// </summary>
        public string CurrentDeviceInfoVersion
        {
            get => this.currentDeviceInfoVersion;

            set
            {
                this.currentDeviceInfoVersion = value;
                this.RaisePropertyChanged();
            }
        }

        public DeviceInfoPageViewModel()
        {
            this.CurrentDeviceInfoName = DeviceInfo.Name;
            this.currentDeviceInfoManufacturer = DeviceInfo.Manufacturer;
            this.CurrentDeviceInfoVersion = DeviceInfo.VersionString;
        }
    }
}
