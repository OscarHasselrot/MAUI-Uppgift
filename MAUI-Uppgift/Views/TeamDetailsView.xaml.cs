using MAUI_Uppgift.ViewModels;

namespace MAUI_Uppgift.Views;

public partial class TeamDetailsView : ContentView
{

	public static readonly BindableProperty TeamProperty =
		BindableProperty.Create(nameof(Team), typeof(TeamItemViewModel), typeof(TeamDetailsView), default(TeamItemViewModel));

	public TeamItemViewModel? Team
	{
		get => (TeamItemViewModel?)GetValue(TeamProperty);
		set => SetValue(TeamProperty, value);
    }
    public TeamDetailsView()
	{
		InitializeComponent();
	}
}