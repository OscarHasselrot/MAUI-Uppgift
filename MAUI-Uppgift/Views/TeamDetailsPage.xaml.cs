using MAUI_Uppgift.ViewModels;

namespace MAUI_Uppgift.Views;

public partial class TeamDetailsPage : ContentPage, IQueryAttributable
{
    private readonly TeamViewModel vm;

    public TeamDetailsPage(TeamViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if(!query.TryGetValue("abbr", out var abbrObj) || abbrObj is null)
        {
            vm.SetError("Missing parameter to load teamdetails.");
            return;
        }
        var abbr = abbrObj.ToString();
        if (string.IsNullOrWhiteSpace(abbr))
        {
            vm.SetError("Invalid team abbreviation");
            return;
        }
        vm.ClearError();
        vm.LoadAllCommand.Execute(abbr);
    }
}