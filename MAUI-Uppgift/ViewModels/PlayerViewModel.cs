using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Uppgift.Models;
using MAUI_Uppgift.Services;
using MAUI_Uppgift.ViewModels.Base;
using System.Collections.ObjectModel;

namespace MAUI_Uppgift.ViewModels
{
    public partial class PlayerViewModel : BaseViewModel
    {
        private readonly PlayerService playerService;
        [ObservableProperty]
        ObservableCollection<Player> players = [];

        public PlayerViewModel() => playerService = new PlayerService();

        [RelayCommand]
        async Task GetPlayersByTeam(string abbreviation)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                Players.Clear();
                var playerList = await playerService.GetPlayersByTeamAsync(abbreviation);
                foreach (var player in playerList)
                    Players.Add(player);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
