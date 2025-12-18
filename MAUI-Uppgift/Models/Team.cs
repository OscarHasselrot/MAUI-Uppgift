namespace MAUI_Uppgift.Models
{
    public class Team
    {
        public int? TeamID { get; set; }
        public string Key { get; set; } = string.Empty;
        public bool? Active { get; set; }
        public string City { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? StadiumID { get; set; }
        public string Conference { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
        public string PrimaryColor { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string TertiaryColor { get; set; } = string.Empty;
        public string QuaternaryColor { get; set; } = string.Empty;
        public string WikipediaLogoUrl { get; set; } = string.Empty;
        public object? WikipediaWordMarkUrl { get; set; }
        public int? GlobalTeamID { get; set; }
        public string HeadCoach { get; set; } = string.Empty;
        public string LogoPath => $"/teams/{Key.ToLower()}.png";
    }


}
