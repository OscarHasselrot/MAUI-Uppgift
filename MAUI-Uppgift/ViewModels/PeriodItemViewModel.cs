using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_Uppgift.Models;
using MAUI_Uppgift.ViewModels.Base;

namespace MAUI_Uppgift.ViewModels
{
    public partial class PeriodItemViewModel: BaseViewModel
    {
        public int PeriodID{ get; }
        [ObservableProperty]
        string name = "";
        [ObservableProperty]
        int awayScore;
        [ObservableProperty]
        int homeScore;
        public PeriodItemViewModel(Period model)
        {
            PeriodID = model.PeriodID;
            UpdateFromModel(model);
        }
        public void UpdateFromModel(Period model)
        {
            Name = model.Name;
            AwayScore = model.AwayScore;
            HomeScore = model.HomeScore;
        }
    }
}
