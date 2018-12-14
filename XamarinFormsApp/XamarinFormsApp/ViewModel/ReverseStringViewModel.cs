namespace XamarinFormsApp.ViewModel
{
    using System;
    using System.Threading.Tasks;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    public class ReverseStringViewModel : ViewModelBase
    {
        #region Private Fields

        private string reverseString;

        private string myText;


        #endregion

        #region Private Methods

        private async Task ReverseCommandExectue()
        {
            if (string.IsNullOrEmpty(this.MyText))
            {
                this.ReverseString = string.Empty;
            }
            else
            {
                var charArray = this.myText.ToCharArray();
                Array.Reverse(charArray);
                this.ReverseString = new string(charArray);
            }
        }

        #endregion

        #region Public Constructors

        public ReverseStringViewModel()
        {
            this.ReverseCommand = new RelayCommand(async () => await this.ReverseCommandExectue());
            this.ThrowCommand = new RelayCommand(() => throw new Exception("La app ha fallado voluntariamente :-)"));
        }

        #endregion

        #region Public Properties

        public string ReverseString
        {
            get { return this.reverseString; }
            set
            {
                this.reverseString = value;
                this.RaisePropertyChanged();
            }
        }

        public string MyText
        {
            get { return this.myText; }
            set
            {
                this.myText = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand ReverseCommand { get; }

        public RelayCommand ThrowCommand { get;  }

        #endregion
    }
}