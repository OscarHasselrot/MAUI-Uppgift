using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Uppgift.Models.Helpers;
using MAUI_Uppgift.Services;
using MAUI_Uppgift.ViewModels.Base;
using System.Collections.ObjectModel;

namespace MAUI_Uppgift.ViewModels
{
    public partial class StandingViewModel : BaseViewModel
    {
        private readonly StandingService standingService;

        [ObservableProperty]
        ObservableCollection<StandingItemViewModel> standings1 = [];
        [ObservableProperty]
        ObservableCollection<StandingItemViewModel> standings2 = [];
        [ObservableProperty]
        string? key;

        public IEnumerable<ConferenceEnum> Conference => Enum.GetValues<ConferenceEnum>().Cast<ConferenceEnum>();
        [ObservableProperty]
        StandingItemViewModel? selectedStanding1;
        [ObservableProperty]
        StandingItemViewModel? selectedStanding2;

        [ObservableProperty]
        string? standingDivision1;

        [ObservableProperty]
        string? standingDivision2;

        [ObservableProperty]
        ConferenceEnum? selectedConference;


        public StandingViewModel(StandingService standingService)
        {
            this.standingService = standingService;
            SelectedConference = Conference.First();

        }
        [RelayCommand]

        async Task SelectTeamAsync(StandingItemViewModel? selected)
        {
            if (selected is null)
                return;
            var teamKey = selected.Key;
            SelectedStanding1 = null;
            SelectedStanding2 = null;
            await Shell.Current.GoToAsync($"teamdetails?abbr={teamKey}");
        }
        [RelayCommand]
        async Task LoadStandingsAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            ClearError();

            try
            {
                Standings1.Clear();
                Standings2.Clear();
                Title = $"NHL Standings";

                var conference = SelectedConference;

                (StandingDivision1, StandingDivision2) = conference == ConferenceEnum.Eastern
                    ? ("Atlantic Division", "Metropolitan Division")
                    : ("Central Division", "Pacific Division");

                var (div1, div2) = await standingService.GetStandingsAsync(conference.ToString());
                foreach (var standing in div1)
                    Standings1.Add(new StandingItemViewModel(standing));

                foreach (var standing in div2)
                    Standings2.Add(new StandingItemViewModel(standing));
            }
            catch (Exception )
            {
                SetError($"Unable to load standings: Check internet connection and try again.");
            }
            finally
            {
                IsBusy = false;
            }
        }
        partial void OnSelectedConferenceChanged(ConferenceEnum? value)
        {
            if (value is null)
                return;
            _ = LoadStandingsAsync();

        }

    }
}
