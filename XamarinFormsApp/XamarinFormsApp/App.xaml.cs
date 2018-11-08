using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsApp
{
    using CommonServiceLocator;

    using GalaSoft.MvvmLight.Views;

    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;

    using XamarinFormsApp.Services;
    using XamarinFormsApp.View;
    using XamarinFormsApp.ViewModel;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ViewModelLocator.SetLocatorProvider();
            var nav = ServiceLocator.Current.GetInstance<INavigationService>() as ExtendedNavigationService;

            var navPage = new NavigationPage(new MainPage());

            nav?.Initialize(navPage);

            this.MainPage = navPage;

            var dialog = ServiceLocator.Current.GetInstance<IDialogService>() as DialogService;
            dialog?.Initialize(this.MainPage);
        }

        protected override void OnStart()
        {
            AppCenter.Start("uwp=53e7bcf5-4288-423d-8a44-86ef2888fda4;" + "android={Your Android App secret here}" + "ios={Your iOS App secret here}", typeof(Analytics));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
