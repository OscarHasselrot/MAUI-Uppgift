using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Uppgift.Models;
using MAUI_Uppgift.Services;
using MAUI_Uppgift.ViewModels.Base;

namespace MAUI_Uppgift.ViewModels
{
    public partial class GameViewModel : BaseViewModel
    {
        private readonly GameService gamesService;

        public record GameRequest(DateTime Date, string Team);

        [ObservableProperty]
        string primaryColor = "#FFFFFF";

        [ObservableProperty]
        GameItemViewModel? currentGame;
        public GameViewModel()
        {
            gamesService = new GameService();
        }

        [RelayCommand]
        async Task LoadGame(GameRequest request)
        {
            IsBusy = true;
            try
            {
                var loaded = await gamesService.GetGameDetailsForTeam(request.Date, request.Team);
                if (loaded is null)
                    return;

                var primaryColor = await gamesService.GetHomeTeamPrimaryColor(loaded.HomeTeam);
                PrimaryColor = primaryColor ?? "#FFFFFF";


                    if (CurrentGame is null)
                        CurrentGame = new GameItemViewModel(loaded);
                    else
                        CurrentGame.UpdateFromModel(loaded);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading game: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
