using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_Uppgift.Models;
using MAUI_Uppgift.ViewModels.Base;
using System.Collections.ObjectModel;


namespace MAUI_Uppgift.ViewModels
{
    public partial class GameItemViewModel : BaseViewModel
    {
        public Game Model { get; private set; } = default!;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AwayTeamLogo))]
        [NotifyPropertyChangedFor(nameof(Matchup))]
        string? awayTeam;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HomeTeamLogo))]
        [NotifyPropertyChangedFor(nameof(Matchup))]
        string? homeTeam;
        [ObservableProperty]
        DateTime dateTime;
        [ObservableProperty]
        int awayTeamScore;
        [ObservableProperty]
        int homeTeamScore;
        [ObservableProperty]
        string? channel;
        [ObservableProperty]
        int attendance;

        public ObservableCollection<PeriodItemViewModel> Periods { get; } = [];
        public string HomeTeamLogo => $"teams/{(HomeTeam ?? "").ToLowerInvariant()}.png";
        public string AwayTeamLogo => $"teams/{(AwayTeam ?? "").ToLowerInvariant()}.png";
        public string DisplayDate => DateTime.ToString("yyyy-MM-dd");
        public string DisplayTime => DateTime.ToLocalTime().ToString("HH:mm");
        public string Matchup => $"{AwayTeam} @ {HomeTeam}";

        public GameItemViewModel()
        {

        }
        public GameItemViewModel(Game model) => UpdateFromModel(model);

        public void UpdateFromModel(Game model)
        {
            Model = model;
            AwayTeam = model.AwayTeam;
            HomeTeam = model.HomeTeam;
            DateTime = model.DateTime;
            AwayTeamScore = model.AwayTeamScore;
            HomeTeamScore = model.HomeTeamScore;
            Channel = model.Channel;
            Attendance = model.Attendance;

            var incomingPeriods = model.Periods ?? [];

            Periods.Clear();
            foreach (var period in incomingPeriods)
                Periods.Add(new PeriodItemViewModel(period));

            OnPropertyChanged(nameof(DisplayDate));
            OnPropertyChanged(nameof(DisplayTime));
            OnPropertyChanged(nameof(Matchup));
        }
    }
}
