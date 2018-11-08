// -------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="CodigoEdulis">
//     Código Edulis 2017 http://www.codigoedulis.es
// </copyright>
// <summary>
// This implementation is a group of the offers of several persons along the network; because of
// this, it is under Creative Common By License:
//
// You are free to:
//
// Share — copy and redistribute the material in any medium or format Adapt — remix, transform, and
// build upon the material for any purpose, even commercially.
//
// The licensor cannot revoke these freedoms as long as you follow the license terms.
//
// Under the following terms:
//
// Attribution — You must give appropriate credit, provide a link to the license, and indicate if
// changes were made. You may do so in any reasonable manner, but not in any way that suggests the
// licensor endorses you or your use. No additional restrictions — You may not apply legal terms or
// technological measures that legally restrict others from doing anything the license permits.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XamarinFormsApp.ViewModel
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Messaging;
    using GalaSoft.MvvmLight.Views;

    using InitXamarinForms.Constants;

    using Xamarin.Forms;

    public class MainViewModel : ParentViewModel
    {
        #region Private Methods

        private async Task OnAppearing()
        {
            Debug.WriteLine("¡¡¡¡¡¡ OnAppearing");
            await Task.Delay(1);
        }

        #endregion

        #region Public Constructors

        public MainViewModel(IMessenger messenger, INavigationService navigationService, IDialogService dialogService)
            : base(messenger, navigationService, dialogService)
        {
            this.OnAppearingCommand = new Command(async () => await this.OnAppearing());
            this.GoToReverseStringPageCommand = new Command(this.NavigateToReverse);
        }

        private void NavigateToReverse()
        {
            this.NavigationService.NavigateTo(AppConstants.NavigationPages.ReverseStringPage);
        }

        #endregion

        #region Public Properties

        public ICommand GoToReverseStringPageCommand { get; }

        public ICommand OnAppearingCommand { get; }

        #endregion
    }
}