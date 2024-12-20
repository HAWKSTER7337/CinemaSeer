namespace CinemaSeer.JsonFormats;

public class MediaItem
{
    public string Title { get; set; }
    public List<int> GenreIds { get; set; }
    public string OverView { get; set; }
    public string ReleaseDate { get; set; }
    public string PosterFileLocation { get; set; }
    
    public Poster Poster { get; set; }
    
    public int Id { get; set; }
    
    public string TypeOfMedia { get; set; }

    public override string ToString()
    {
        var formattedString = $"{Title}\n{ReleaseDate}\n{OverView}\n";
        return formattedString;
    }
}