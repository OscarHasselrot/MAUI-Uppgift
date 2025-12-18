using MAUI_Uppgift.ViewModels;

namespace MAUI_Uppgift.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(StandingViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.LoadStandingsCommand.Execute(null);
        }
    }
}
