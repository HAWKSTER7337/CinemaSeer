using System.Text.Json.Serialization;

namespace CinemaSeer.JsonFormats;

public class MediaResponse<TMedia> where TMedia : class, IMedia
{
    [JsonPropertyName("page")]
    public int Page {get; set;}
    
    [JsonPropertyName("results")]
    public List<TMedia> Results {get; set;}
    
    [JsonPropertyName("total_pages")]
    public int totalPages {get; set;}
    
    [JsonPropertyName("total_results")]
    public int totalResults { get; set; }
}