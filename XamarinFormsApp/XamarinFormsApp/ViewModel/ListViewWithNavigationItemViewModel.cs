using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GalaSoft.MvvmLight;

    using Xamarin.Forms;

    public class ListViewWithNavigationItemViewModel: ViewModelBase
    {
        public ObservableCollection<String> Items => new ObservableCollection<String>() { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };

        public ICommand SelectedItemCommand { get; set; }

        public ListViewWithNavigationItemViewModel()
        {
            SelectedItemCommand = new Command<String>(SelectedItem);
        }

        private void SelectedItem(String param)
        {
            App.Current.MainPage.DisplayAlert("SelectedItem", param, "Ok");
        }
    }
}
