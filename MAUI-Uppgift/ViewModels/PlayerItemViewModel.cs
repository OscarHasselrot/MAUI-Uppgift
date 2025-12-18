using MAUI_Uppgift.Models;
using MAUI_Uppgift.ViewModels.Base;

namespace MAUI_Uppgift.ViewModels
{
    public class PlayerItemViewModel(Player model) : BaseViewModel
    {
        public Player Model { get; } = model;
        public string FullName => $"{Model.FirstName} {Model.LastName}";
        public string Position => Model.Position ?? "N/A";
        public int? Jersey => Model.Jersey ?? null;
        public string PhotoPath => Model.PhotoUrl ?? "/images/default_player.png";

    }
}
