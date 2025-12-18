using MAUI_Uppgift.Models;
using System.Net.Http.Json;

namespace MAUI_Uppgift.Services
{
    public class PlayerService
    {
        HttpClient httpClient;
        public PlayerService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Player>> GetPlayersByTeamAsync(string team)
        {
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/Players/{team}?key={Config.ApiKey}";
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var players = await response.Content.ReadFromJsonAsync<List<Player>>();
            if (players != null)
            {
                players = [.. players.Where(p => p.Status == "Active")];
            }
            return players!;
        }
    }
}
