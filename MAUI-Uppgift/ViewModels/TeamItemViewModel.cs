using MAUI_Uppgift.Models;
using MAUI_Uppgift.ViewModels.Base;

namespace MAUI_Uppgift.ViewModels
{
    public class TeamItemViewModel(Team model) : BaseViewModel
    {
        public Team Model { get; } = model;

        public string Division => Model.Division;
        public string Conference => Model.Conference;
        public string HeadCoach => Model.HeadCoach;
        public string DisplayName => $"{Model.City} {Model.Name}";

        public string PrimaryColor => $"#{Model.PrimaryColor}";
        public string SecondaryColor => $"#{Model.SecondaryColor}";
        public string LogoPath => $"/teams/{Model.Key.ToLower()}.png";


    }
}