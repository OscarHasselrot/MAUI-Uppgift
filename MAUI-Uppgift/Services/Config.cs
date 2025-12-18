using System.Reflection;
using System.Text.Json;

namespace MAUI_Uppgift.Services
{
    public static class Config
    {
        private static readonly Lazy<JsonElement> config = new(() =>
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("MAUI_Uppgift.appsettings.json");
            using var reader = new StreamReader(stream!);
            var json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<JsonElement>(json)!;
        });

        public static string ApiKey => config.Value.GetProperty("API_KEY").GetString() ?? string.Empty;
    }
}
