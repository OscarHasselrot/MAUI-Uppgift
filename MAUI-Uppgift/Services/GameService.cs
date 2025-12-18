using MAUI_Uppgift.Models;
using System.Net.Http.Json;

namespace MAUI_Uppgift.Services
{
    public class GameService
    {
        private readonly HttpClient httpClient;
        private readonly AppSettings appSettings;

        public GameService(HttpClient httpClient, AppSettings appSettings)
        {
            this.httpClient = httpClient;
            this.appSettings = appSettings;
        }

        public async Task<List<ScheduleBasic>> GetPreviousGamesByTeam(string abbreviation)
        {
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/SchedulesBasic/{appSettings.Season}?key={Config.ApiKey}";
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var schedule = await response.Content.ReadFromJsonAsync<List<ScheduleBasic>>();
            if (schedule != null)
            {
                return [.. schedule
                    .Where(s => (s.AwayTeam == abbreviation || s.HomeTeam == abbreviation) && s.IsClosed)
                    .OrderByDescending(s => s.GameID)];
            }
            else
            {
                return [];
            }
        }
        public async Task<List<ScheduleBasic>> GetUpcomingGamesByTeam(string abbreviation)
        {
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/SchedulesBasic/{appSettings.Season}?key={Config.ApiKey}";
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var schedule = await response.Content.ReadFromJsonAsync<List<ScheduleBasic>>();
            if (schedule != null)
            {
                return [.. schedule
                    .Where(s => (s.AwayTeam == abbreviation || s.HomeTeam == abbreviation) && !s.IsClosed)
                    .OrderBy(s => s.GameID)];
            }
            else
            {
                return [];
            }
        }

        public async Task<Game?> GetGameDetailsForTeam(DateTime date, string abbreviation)
        {
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/GamesByDateFinal/{date:yyyy-MM-dd}?key={Config.ApiKey}";
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var games = await response.Content.ReadFromJsonAsync<List<Game>>();

            var game = games?.FirstOrDefault(g =>
                string.Equals(g.AwayTeam, abbreviation, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(g.HomeTeam, abbreviation, StringComparison.OrdinalIgnoreCase));
            return game;
        }

        public async Task<string?> GetHomeTeamPrimaryColor(string abbreviation)
        {
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/teams?key={Config.ApiKey}";
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var teams = await response.Content.ReadFromJsonAsync<List<Team>>();
            if (teams == null)
                return null;

            var team = teams.FirstOrDefault(t => t.Key == abbreviation);

            var primaryColor = $"#{team?.PrimaryColor}";
            return primaryColor;



        }
    }
}
