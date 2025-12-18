using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_Uppgift.Models;

namespace MAUI_Uppgift.ViewModels
{
    public partial class StandingItemViewModel(Standing model) : ObservableObject
    {
        public Standing Model { get; } = model;

        public string Key => Model.Key;
        public string DisplayName => $"{Model.City} {Model.Name}";
        public int GamesPlayed => (Model.Wins ?? 0) + (Model.Losses ?? 0) + (Model.OvertimeLosses ?? 0);
        public int? Points => (Model.Wins ?? 0) * 2 + (Model.OvertimeLosses ?? 0);
        public string LogoPath => $"/teams/{Model.Key?.ToLower()}.png";
        public string Name => Model.Name;
        public int Wins => Model.Wins ?? 0;
        public int Losses => Model.Losses ?? 0;
        public int OvertimeLosses => Model.OvertimeLosses ?? 0;
    }
}
