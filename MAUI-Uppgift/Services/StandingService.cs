
using MAUI_Uppgift.Models;
using System.Net.Http.Json;

namespace MAUI_Uppgift.Services
{
    public class StandingService
    {
        HttpClient httpClient;
        public StandingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<(List<Standing> div1, List<Standing> div2)> GetStandingsAsync(int season, string? conference)
        {
            if (conference is null || (conference != "Eastern" && conference != "Western"))
                return ([], []);
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/Standings/{season}?key={Config.ApiKey}";

            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var standings = await response.Content.ReadFromJsonAsync<List<Standing>>() ?? [];

            var filtered = standings.Where(s => s.Conference == conference).OrderBy(s => s.DivisionRank);
            return conference switch
            {
                "Eastern" => ([.. filtered.Where(s => s.Division == "Atlantic")],
                               [.. filtered.Where(s => s.Division == "Metropolitan")]),
                "Western" => ([.. filtered.Where(s => s.Division == "Central")],
                               [.. filtered.Where(s => s.Division == "Pacific")]),
                _ => ([], []),
            };
        }
    }
}
