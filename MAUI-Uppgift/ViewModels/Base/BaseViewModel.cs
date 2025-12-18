using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI_Uppgift.ViewModels.Base
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? title;
        [ObservableProperty]
        private bool isBusy;

    }
}
