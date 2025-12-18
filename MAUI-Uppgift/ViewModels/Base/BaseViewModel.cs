using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI_Uppgift.ViewModels.Base
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? title;
        [ObservableProperty]
        private bool isBusy;
        [ObservableProperty]
        private string? errorMessage;
        [ObservableProperty]
        private bool hasError;


        public void SetError(string message)
        {
            ErrorMessage = message;
            HasError = true;
        }
        public void ClearError()
        {
            ErrorMessage = null;
            HasError = false;
        }
    }
}
