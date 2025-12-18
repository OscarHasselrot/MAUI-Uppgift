using MAUI_Uppgift.ViewModels;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MAUI_Uppgift.Views;

public partial class GameDetailPage : ContentPage, IQueryAttributable
{
    private readonly GameViewModel vm;


    public GameDetailPage(GameViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        try
        {
            if (!query.TryGetValue("date", out var dateObj) ||
                !query.TryGetValue("team", out var teamObj))
                return;

            var dateText = dateObj?.ToString();
            var team = teamObj?.ToString();

            if (string.IsNullOrWhiteSpace(dateText) || string.IsNullOrWhiteSpace(team))
                return;

            if (!DateTime.TryParseExact(dateText, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return;

            vm.LoadGameCommand.Execute(new GameViewModel.GameRequest(date, team));
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"ApplyQueryAttributes ERROR: {ex}");
        }
    }
}