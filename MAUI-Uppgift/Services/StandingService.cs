
using MAUI_Uppgift.Models;
using System.Net.Http.Json;

namespace MAUI_Uppgift.Services
{
    public class StandingService
    {
        HttpClient httpClient;
        public StandingService()
        {
            httpClient = new HttpClient();
        }
        public async Task<(List<Standing> div1, List<Standing> div2)> GetStandingsAsync(string? conference)
        {
            if (conference is null || (conference != "Eastern" && conference != "Western"))
                return ([], []);
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/Standings/2026?key={Config.ApiKey}";

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
