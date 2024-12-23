using System.Text.Json.Serialization;

namespace CinemaSeer.JsonFormats;

public class Person : IMedia
{
    [JsonPropertyName("adult")]
    public bool? Adult { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }
    
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("known_for_department")]
    public string? KnownForDepartment { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("original_name")]
    public string? OriginalName { get; set; }
    
    [JsonPropertyName("popularity")]
    public double? Popularity { get; set; }
    
    [JsonPropertyName("profile_path")]
    public string? ProfilePath { get; set; }
    
    [JsonPropertyName("known_for")]
    public List<Movie>? KnownFor { get; set; }
    
    public MediaItem GetInfo()
    {
        var mediaItem = new MediaItem
        {
            Title = Name,
            GenreIds = null,
            ReleaseDate = null,
            OverView = KnownForDepartment,
            PosterFileLocation = BackdropPath,
            Id = Id ?? 0,
            TypeOfMedia = TypeOfMedia.Person,
            KnownFor = KnownFor,
        };
        return mediaItem;
    }

    public string ToBasicDataString()
    {
        var returnString = string.Empty;
        returnString += $"Name: {Name ?? string.Empty}\n";
        returnString += $"Known For Department: {KnownForDepartment ?? string.Empty}\n";
        returnString += $"Popularity: {Popularity ?? 0d}\n";
        return returnString;    
    }
}