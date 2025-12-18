namespace MAUI_Uppgift.Services
{
    public class AppSettings
    {
        private const string SeasonKey = "Season";

        public int Season
        {
            get => Preferences.Get(SeasonKey, DefaultSeason());
            set => Preferences.Set(SeasonKey, value);
        }
        private static int DefaultSeason()
        {
            var now = DateTime.UtcNow;
            return now.Month >= 9 ? now.Year + 1 : now.Year;
        }
    }
}
