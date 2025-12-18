namespace MAUI_Uppgift.Models
{
    public class Period
    {
        public int PeriodID { get; set; }
        public int GameID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AwayScore { get; set; }
        public int HomeScore { get; set; }

    }


}
