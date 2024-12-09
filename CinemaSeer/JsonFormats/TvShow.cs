using System.Text.Json.Serialization;

namespace CinemaSeer.JsonFormats;

public class TvShow : IMedia
{
    [JsonPropertyName("backdrop_path")]
    public string backDropPath { get; set; }
    
    [JsonPropertyName("first_air_date")]
    public string firstAirDate { get; set; }
    
    [JsonPropertyName("genre_ids")]
    public List<int> genreIds { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("origin_country")]
    public string OriginCountry { get; set; }
    
    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }
    
    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; }
    
    [JsonPropertyName("overview")]
    public string Overview { get; set; }
    
    [JsonPropertyName("popularity")]
    public int Popularity { get; set; }
    
    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }
    
    [JsonPropertyName("vote_average")]
    public int VoteAverage { get; set; }
    
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
    public MediaItem GetInfo()
    {
        var mediaItem = new MediaItem();
        mediaItem.Title = Name;
        mediaItem.GenreIds = genreIds;
        mediaItem.OverView = Overview;
        mediaItem.ReleaseDate = firstAirDate;
        return mediaItem;
    }
}