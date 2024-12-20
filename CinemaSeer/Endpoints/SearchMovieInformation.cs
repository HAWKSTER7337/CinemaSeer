using CinemaSeer.JsonFormats;

namespace CinemaSeer.Endpoints;

public class SearchMovieInformation : VideoEndpoint<Movie>
{
    // Filter Options 
    public string? Query { get; set; }
    
    public int? Page { get; set; }

    public string? Language { get; set; } = "en-US";

    public string? PrimaryReleaseYear { get; set; }
    
    public string? Region { get; set; }
    
    public string? Year { get; set; }

    public SearchMovieInformation() : base("https://api.themoviedb.org/3/search/movie")
    {}
    
    public override void PopulateParameters()
    {
        ClearParametersString();
        if (Page != null)
        {
            Parameters = $"page={Page}";
        }
        
        if (Query != null)
        {
            Parameters = $"query={Query}";
        }

        if (Language != null)
        {
            Parameters = $"language={Language}";
        }

        if (PrimaryReleaseYear != null)
        {
            Parameters = $"primary_release_year={PrimaryReleaseYear}";
        }

        if (Region != null)
        {
            Parameters = $"region={Region}";
        }

        if (Year != null)
        {
            Parameters = $"year={Year}";
        }
        
    }

    public override void EmptyParameters()
    {
        ClearParametersString();
        Page = null;
        Year = null;
        Query = null;
        Language = null;
        Region = null;
        PrimaryReleaseYear = null;
    }
}