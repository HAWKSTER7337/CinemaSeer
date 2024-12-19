using CinemaSeer.JsonFormats;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an endpoint for discovering movie information using the Movie Database API.
/// </summary>
/// <remarks>
/// This class is a specific implementation of the MovieEndpoint abstract class.
/// It utilizes the "discover/movie" API endpoint to retrieve a list of movies
/// based on certain criteria. The endpoint URL is constructed with optional parameters
/// and includes necessary headers for authorization.
/// </remarks>
public class DiscoverMoviesInformationEndpoint : VideoEndpoint<Movie>
{
    // Filter Options 
    public int? Page { get; set; }
    public int? Year { get; set; }
    public bool? IncludeAdult { get; set; }
    public string? SortBy { get; set; }
    
    public DiscoverMoviesInformationEndpoint() : base("https://api.themoviedb.org/3/discover/movie")
    {}

    public override void PopulateParameters()
    {
        ClearParametersString();
        if (Page != null)
        {
            Parameters = $"page={Page}";
        }
        
        if (Year != null)
        {
            Parameters = $"year={Year}";
        }

        if (IncludeAdult != null)
        {
            Parameters = $"include_adult={IncludeAdult}";
        }

        if (SortBy != null)
        {
            Parameters = $"sort_by={SortBy}";
        }
    }

    public override void EmptyParameters()
    {
        ClearParametersString();
        Page = null;
        Year = null;
        IncludeAdult = null;
    }
}