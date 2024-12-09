using System.Text.Json.Serialization;

namespace CinemaSeer.JsonFormats;

public class MediaResponse
{
    [JsonPropertyName("page")]
    public int Page {get; set;}
    
    [JsonPropertyName("results")]
    public List<IMedia> Results {get; set;}
    
    [JsonPropertyName("total_pages")]
    public int totalPages {get; set;}
    
    [JsonPropertyName("total_results")]
    public int totalResults { get; set; }

    public void MergeAnotherMediaResponseIntoThisOne(MediaResponse otherMediaResponse)
    {
        Results.AddRange(otherMediaResponse.Results);
    }
}