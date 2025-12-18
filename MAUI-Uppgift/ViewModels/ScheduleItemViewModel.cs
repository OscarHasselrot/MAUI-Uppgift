using MAUI_Uppgift.Models;
using MAUI_Uppgift.ViewModels.Base;
using System.Globalization;

namespace MAUI_Uppgift.ViewModels
{
    public class ScheduleItemViewModel(ScheduleBasic model) : BaseViewModel
    {
        public ScheduleBasic Model { get; } = model;

        public string HomeLogoPath => $"{Model.HomeTeam.ToLowerInvariant()}.png";
        public string AwayLogoPath => $"{Model.AwayTeam.ToLowerInvariant()}.png";
        public string DisplayDate => Model.DateTimeUTC?.ToLocalTime().ToString("g") ?? string.Empty;
        public string DateKey => Model.DateTime?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) ?? string.Empty;
        public string AwayTeamScore => Model.AwayTeamScore?.ToString() ?? "-";
        public string HomeTeamScore => Model.HomeTeamScore?.ToString() ?? "-";

    }
}
