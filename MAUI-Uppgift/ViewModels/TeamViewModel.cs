using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Uppgift.Models;
using MAUI_Uppgift.Services;
using MAUI_Uppgift.ViewModels.Base;
using System.Collections.ObjectModel;

namespace MAUI_Uppgift.ViewModels
{
    public partial class TeamViewModel : BaseViewModel
    {
        private readonly TeamService teamService;
        private readonly GameService scheduleService;
        [ObservableProperty]
        TeamItemViewModel? selectedTeam;
        [ObservableProperty]
        ObservableCollection<ScheduleItemViewModel> previousGames = [];
        [ObservableProperty]
        ObservableCollection<ScheduleItemViewModel> upcomingGames = [];
        [ObservableProperty]
        string? abbreviation;
        [ObservableProperty]
        string? primaryColor;
        [ObservableProperty]
        string? secondaryColor;
        [ObservableProperty]
        bool isPreviousGamesExpanded = true;
        [ObservableProperty]
        private ScheduleItemViewModel? selectedPreviousGame;
        [ObservableProperty]
        private ScheduleItemViewModel? selectedUpcomingGame;
        public TeamViewModel()
        {
            teamService = new TeamService();
            scheduleService = new GameService();
        }

        [RelayCommand]
        void TogglePreviousGames() => IsPreviousGamesExpanded = !IsPreviousGamesExpanded;

        [RelayCommand]
        async Task SelectGameAsync(ScheduleItemViewModel? game)
        {
            if (game is null) return;
            if (string.IsNullOrWhiteSpace(Abbreviation)) return;

            await Shell.Current.GoToAsync("gamedetails", new Dictionary<string, object>
            {
                ["date"] = game.DateKey,
                ["team"] = Abbreviation
            });

            SelectedPreviousGame = null;
            SelectedUpcomingGame = null;
        }

        [RelayCommand]
        async Task LoadAllAsync(string abbreviation)
        {
            if (IsBusy)
                return;
            ClearError();
            IsBusy = true;
            Abbreviation = abbreviation;

            try
            {
                PreviousGames.Clear();
                UpcomingGames.Clear();

                var teamsTask = teamService.GetTeamByAbbreviationAsync(abbreviation);
                var previousGamesTask = scheduleService.GetPreviousGamesByTeam(abbreviation);
                var upcomingGamesTask = scheduleService.GetUpcomingGamesByTeam(abbreviation);

                await Task.WhenAll(teamsTask, previousGamesTask, upcomingGamesTask);

                var team = await teamsTask;
                var previousGames = await previousGamesTask;
                var upcomingGames = await upcomingGamesTask;

                if (team is null)
                {
                    IsBusy = false;
                    return;
                }
                SelectedTeam = new TeamItemViewModel(team);

                Title = SelectedTeam.DisplayName;
                PrimaryColor = SelectedTeam.PrimaryColor;
                SecondaryColor = SelectedTeam.SecondaryColor;

                if (previousGames is not null)
                {
                    foreach (var game in previousGames)
                        PreviousGames.Add(new ScheduleItemViewModel(game));
                }
                if (upcomingGames is not null)
                {
                    foreach (var game in upcomingGames)
                        UpcomingGames.Add(new ScheduleItemViewModel(game));
                }

            }
            catch(Exception)
            {
                SetError("Error loading team");
            }
            finally
            {
                IsBusy = false;
            }

        }


    }

}

