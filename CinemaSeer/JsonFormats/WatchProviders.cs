using System.Text;
using System.Text.Json.Serialization;

namespace CinemaSeer.JsonFormats;

public class WatchProviders
{
    public string? nameOfMovie { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("results")]
    public Dictionary<string, RegionResults>? Results { get; set; }

    public string GetUSPlacesToStream()
    {
        var returnString = CheckIfLocationExists("US");
        if (returnString != string.Empty) return returnString;
        
        var region = Results["US"];
        return region.FlatRate != null ? GetPlacesToView(region.FlatRate) : "";
    }

    private string CheckIfLocationExists(string location)
    {
        return Results == null || !Results.ContainsKey(location) ? 
            $"The location {location} was not found for {nameOfMovie}.\n" : string.Empty;
    }

    private string GetPlacesToView(List<WatchLocation> locations)
    {
        var placesToWatch = new StringBuilder();
        placesToWatch.AppendLine($"Places to Watch \"{nameOfMovie}\"");
        locations.ForEach(location => placesToWatch.AppendLine(location.ProviderName));
        return placesToWatch.ToString();
    }
    
    
}

public struct RegionResults
{
    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("rent")]
    public List<WatchLocation> Rent { get; set; }
    
    [JsonPropertyName("flatrate")]
    public List<WatchLocation> FlatRate { get; set; }
    
    [JsonPropertyName("buy")]
    public List<WatchLocation> Buy { get; set; }
}

public struct WatchLocation
{
    [JsonPropertyName("logo_path")]
    public string LogoPath { get; set; }

    [JsonPropertyName("provider_id")]
    public int ProviderId { get; set; }

    [JsonPropertyName("provider_name")]
    public string ProviderName { get; set; }
    
    [JsonPropertyName("display_priority")]
    public int DisplayPriority { get; set; }
}
