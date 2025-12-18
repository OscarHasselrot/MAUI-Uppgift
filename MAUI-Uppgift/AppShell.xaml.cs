using MAUI_Uppgift.Views;

namespace MAUI_Uppgift
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("teamdetails", typeof(TeamDetailsPage));
            Routing.RegisterRoute("gamedetails", typeof(GameDetailPage));
        }
    }
}
