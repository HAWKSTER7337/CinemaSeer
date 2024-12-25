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
    public List<string> OriginCountry { get; set; }
    
    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }
    
    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; }
    
    [JsonPropertyName("overview")]
    public string Overview { get; set; }
    
    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }
    
    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }
    
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
    public MediaItem GetInfo()
    {
        var mediaItem = new MediaItem
        {
            Title = Name,
            GenreIds = genreIds,
            OverView = Overview,
            ReleaseDate = firstAirDate,
            PosterFileLocation = PosterPath,
            Id = Id,
            TypeOfMedia = TypeOfMedia.TvShow
        };
        return mediaItem;
    }

    public string ToBasicDataString()
    {
        var mediaItem = GetInfo();
        return mediaItem.ToString();
    }
}