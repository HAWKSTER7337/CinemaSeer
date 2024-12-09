namespace CinemaSeer.JsonFormats;

public class MediaItem
{
    public string Title { get; set; }
    public List<int> GenreIds { get; set; }
    public string OverView { get; set; }
    public string ReleaseDate { get; set; }

    public override string ToString()
    {
        var formattedString = $"{Title}\n{ReleaseDate}\n{OverView}\n";
        return formattedString;
    }
}