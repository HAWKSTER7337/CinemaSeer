using CinemaSeer.JsonFormats;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an endpoint for discovering TV show information from the TheMovieDB API.
/// </summary>
/// <remarks>
/// Inherits the <see cref="VideoEndpoint{TMedia}"/> class to provide a specialized implementation for retrieving TV show data.
/// Utilizes RESTful requests to fetch data by making use of a specific API endpoint URL.
/// </remarks>
public class DiscoverTvShowInformationEndpoint : VideoEndpoint<TvShow>
{
    // Filter Options
    public int? Page { get; set; }
    public bool? IncludeAdult { get; set; }
    public string? Region {get; set;}
    
    public string? SortBy {get; set;}
    
    public DiscoverTvShowInformationEndpoint() : base("https://api.themoviedb.org/3/discover/tv")
    {}
    
    public override void PopulateParameters()
    {
        ClearParametersString();
        if (Page != null)
        {
            Parameters = $"page={Page}";
        }
        
        if (IncludeAdult != null)
        {
            Parameters = $"include_adult={IncludeAdult}";
        }
        
        if (Region != null)
        {
            Parameters = $"region={Region}";
        }

        if (SortBy != null)
        {
            Parameters = $"sort_by={SortBy}";
        }
    }

    public override void EmptyParameters()
    {
        Page = null;
        IncludeAdult = null;
        Region = null;
    }
}