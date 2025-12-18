namespace MAUI_Uppgift.Models
{
    public class Standing
    {
        public int? Season { get; set; }
        public int? SeasonType { get; set; }
        public int? TeamID { get; set; }
        public string Key { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Conference { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? OvertimeLosses { get; set; }
        public double? Percentage { get; set; }
        public int? ConferenceWins { get; set; }
        public int? ConferenceLosses { get; set; }
        public int? DivisionWins { get; set; }
        public int? DivisionLosses { get; set; }
        public int? ShutoutWins { get; set; }
        public int? ConferenceRank { get; set; }
        public int? DivisionRank { get; set; }
        public int? GlobalTeamID { get; set; }

    }
}
