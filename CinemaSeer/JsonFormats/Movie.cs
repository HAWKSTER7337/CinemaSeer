using System.Text.Json.Serialization;

namespace CinemaSeer.JsonFormats;

public class Movie : IMedia
{
    [JsonPropertyName("adult")]
    public bool Adult { get; set; }
    
    [JsonPropertyName("backdrop_path")]
    public string BackdropPath { get; set; }
    
    [JsonPropertyName("genre_ids")]
    public List<int> GenreIds { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }
    
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; }
    
    [JsonPropertyName("overview")]
    public string Overview { get; set; }
    
    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }
    
    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("video")]
    public bool Video {get; set;}
    
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
    
    public MediaItem GetInfo()
    {
        var mediaItem = new MediaItem();
        mediaItem.Title = Title;
        mediaItem.GenreIds = GenreIds;
        mediaItem.ReleaseDate = ReleaseDate;
        mediaItem.OverView = Overview;
        mediaItem.PosterFileLocation = PosterPath;
        return mediaItem;
    }

    public string ToBasicDataString()
    {
        var mediaItem = GetInfo();
        return mediaItem.ToString();
    }
}