using MAUI_Uppgift.ViewModels;

namespace MAUI_Uppgift.Views;

[QueryProperty(nameof(Abbreviation), "abbr")]
public partial class TeamDetailsPage : ContentPage
{
    private readonly TeamViewModel vm;

    public string Abbreviation
    {
        get => vm.Abbreviation!;
        set
        {
            vm.Abbreviation = value;
            vm.LoadAllCommand.Execute(value);
        }
    }

    public TeamDetailsPage(TeamViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
    }

}