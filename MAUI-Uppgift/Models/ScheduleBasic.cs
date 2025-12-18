namespace MAUI_Uppgift.Models;

public class ScheduleBasic
{
    public int GameID { get; set; }
    public int Season { get; set; }
    public int SeasonType { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime Day { get; set; }
    public DateTime? DateTime { get; set; }
    public DateTime Updated { get; set; }
    public bool IsClosed { get; set; }
    public string AwayTeam { get; set; } = string.Empty;
    public string HomeTeam { get; set; } = string.Empty;
    public int StadiumID { get; set; }
    public int? AwayTeamScore { get; set; }
    public int? HomeTeamScore { get; set; }
    public int GlobalGameID { get; set; }
    public int GlobalAwayTeamID { get; set; }
    public int GlobalHomeTeamID { get; set; }
    public DateTime? GameEndDateTime { get; set; }
    public bool NeutralVenue { get; set; }
    public DateTime? DateTimeUTC { get; set; }
    public int AwayTeamID { get; set; }
    public int HomeTeamID { get; set; }
    public object? SeriesInfo { get; set; }

}



