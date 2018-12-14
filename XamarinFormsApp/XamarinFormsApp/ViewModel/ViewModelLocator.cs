/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:XamarinFormsDemo"
                           x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

namespace XamarinFormsApp.ViewModel
{
    using CommonServiceLocator;

    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using GalaSoft.MvvmLight.Views;

    using InitXamarinForms.Constants;

    using XamarinFormsApp.Services;
    using XamarinFormsApp.View;

    /// <summary>
    /// This class contains static references to all the view models in the application and provides
    /// an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            SetLocatorProvider();
        }

        #endregion

        #region Public Properties

        public MainViewModel MainVm => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ReverseStringViewModel ReverseStringVm => ServiceLocator.Current.GetInstance<ReverseStringViewModel>();

        public DeviceInfoPageViewModel DeviceInfoVm => ServiceLocator.Current.GetInstance<DeviceInfoPageViewModel>();

        #endregion

        #region Public Methods

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        public static ExtendedNavigationService ConfigureNavigationPages()
        {
            var nav = new ExtendedNavigationService();

            nav.Configure(AppConstants.NavigationPages.MainPage, typeof(MainPage));
            nav.Configure(AppConstants.NavigationPages.ReverseStringPage, typeof(ReverseStringPage));
            nav.Configure(AppConstants.NavigationPages.DeviceInfoPage, typeof(DeviceInfoPage));

            return nav;
        }

        public static void RegisterInIocContainer()
        {
            SimpleIoc.Default.Register<IMessenger, Messenger>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            var nav = ConfigureNavigationPages();
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ParentViewModel>(true);
            SimpleIoc.Default.Register<ReverseStringViewModel>();
            SimpleIoc.Default.Register<DeviceInfoPageViewModel>();
        }

        public static void SetLocatorProvider()
        {
            if (!ServiceLocator.IsLocationProviderSet)
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                RegisterInIocContainer();
            }
        }

        #endregion
    }
}