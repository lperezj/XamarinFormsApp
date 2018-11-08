namespace XamarinFormsApp.View
{
    using CommonServiceLocator;

    using Xamarin.Forms;

    using XamarinFormsApp.ViewModel;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = ServiceLocator.Current.GetInstance<MainViewModel>();
            vm?.OnAppearingCommand.Execute(null);
        }
    }
}
