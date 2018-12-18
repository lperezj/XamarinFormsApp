namespace XamarinFormsApp.UnitTest
{
    using GalaSoft.MvvmLight.Views;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        private IDialogService dialogService;

        [TestInitialize]
        public void Init()
        {
            this.dialogService = new Services.DialogService();
        }


        [TestMethod]
        public void GivenAuser_WhenPushesTheButtonAndFieldIsEmpty_ViewTheReverseStringEmpty()
        {
            // Arrange
            var text = string.Empty;
            var vm = new ViewModel.ReverseStringViewModel() { MyText = text };

            // Act
            vm.ReverseCommand.Execute(null);

            // Assert
            Assert.AreEqual("", vm.ReverseString);
        }

        [TestMethod]
        public void GivenAuser_WhenPushesTheButtonAndFieldIsNOtEmpty_ShowReverseOrder()
        {
            // Arrange
            var text = "hello";
            var vm = new ViewModel.ReverseStringViewModel() { MyText = text };

            // Act
            vm.ReverseCommand.Execute(null);

            // Assert
            Assert.AreEqual("olleh", vm.ReverseString);
        }
    }
}
