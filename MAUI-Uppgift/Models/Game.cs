namespace MAUI_Uppgift.Models
{

    public class Game
    {
        public int GameID { get; set; }
        public int Season { get; set; }
        public int SeasonType { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime Day { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime Updated { get; set; }
        public bool IsClosed { get; set; }
        public string AwayTeam { get; set; } = string.Empty;
        public string HomeTeam { get; set; } = string.Empty;
        public int AwayTeamID { get; set; }
        public int HomeTeamID { get; set; }
        public int StadiumID { get; set; }
        public string Channel { get; set; } = string.Empty;
        public int Attendance { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamScore { get; set; }
        public object? Period { get; set; }
        public object? TimeRemainingMinutes { get; set; }
        public object? TimeRemainingSeconds { get; set; }
        public int AwayTeamMoneyLine { get; set; }
        public int HomeTeamMoneyLine { get; set; }
        public double PointSpread { get; set; }
        public double OverUnder { get; set; }
        public int GlobalGameID { get; set; }
        public int GlobalAwayTeamID { get; set; }
        public int GlobalHomeTeamID { get; set; }
        public int PointSpreadAwayTeamMoneyLine { get; set; }
        public int PointSpreadHomeTeamMoneyLine { get; set; }
        public object? LastPlay { get; set; }
        public DateTime GameEndDateTime { get; set; }
        public int HomeRotationNumber { get; set; }
        public int AwayRotationNumber { get; set; }
        public bool NeutralVenue { get; set; }
        public int OverPayout { get; set; }
        public int UnderPayout { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public object? SeriesInfo { get; set; }
        public List<Period> Periods { get; set; } = [];
    }


}
