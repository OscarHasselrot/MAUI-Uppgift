using MAUI_Uppgift.Models;
using System.Net.Http.Json;

namespace MAUI_Uppgift.Services
{
    public class TeamService
    {
        private readonly HttpClient httpClient;
        public TeamService()
        {
            this.httpClient = new HttpClient();
        }
        public async Task<Team?> GetTeamByAbbreviationAsync(string team)
        {
            var url = $"https://api.sportsdata.io/v3/nhl/scores/json/teams?key={Config.ApiKey}";
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var teams = await response.Content.ReadFromJsonAsync<List<Team>>();
            if (teams != null)
            {
                teams = [.. teams.Where(t => t.Key == team)];
                return teams.FirstOrDefault()!;
            }
            else
            {
                return null;
            }
        }

        
    }
}
