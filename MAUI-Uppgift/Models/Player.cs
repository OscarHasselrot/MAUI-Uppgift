namespace MAUI_Uppgift.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int TeamID { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int? Jersey { get; set; }
        public string Catches { get; set; } = string.Empty;
        public string Shoots { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthCity { get; set; } = string.Empty;
        public string BirthState { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string SportRadarPlayerID { get; set; } = string.Empty;
        public int? RotoworldPlayerID { get; set; }
        public int? RotoWirePlayerID { get; set; }
        public int? FantasyAlarmPlayerID { get; set; }
        public int? StatsPlayerID { get; set; }
        public int? SportsDirectPlayerID { get; set; }
        public int? XmlTeamPlayerID { get; set; }
        public string InjuryStatus { get; set; } = string.Empty;
        public string InjuryBodyPart { get; set; } = string.Empty;
        public DateTime? InjuryStartDate { get; set; }
        public string InjuryNotes { get; set; } = string.Empty;
        public int? FanDuelPlayerID { get; set; }
        public int? DraftKingsPlayerID { get; set; }
        public int? YahooPlayerID { get; set; }
        public string FanDuelName { get; set; } = string.Empty;    
        public string DraftKingsName { get; set; } = string.Empty;
        public string YahooName { get; set; } = string.Empty;
        public string DepthChartPosition { get; set; } = string.Empty;  
        public int? DepthChartOrder { get; set; }
        public int GlobalTeamID { get; set; }
        public string FantasyDraftName { get; set; } = string.Empty;
        public int? FantasyDraftPlayerID { get; set; }
        public int? UsaTodayPlayerID { get; set; }
        public string UsaTodayHeadshotUrl { get; set; } = string.Empty;
        public string UsaTodayHeadshotNoBackgroundUrl { get; set; } = string.Empty;
        public DateTime? UsaTodayHeadshotUpdated { get; set; }
        public DateTime? UsaTodayHeadshotNoBackgroundUpdated { get; set; }
        public string DisplayName => $"{FirstName} {LastName}";

    }


}



