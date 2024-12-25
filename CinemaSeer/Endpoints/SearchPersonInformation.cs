using CinemaSeer.JsonFormats;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an endpoint to search for person-related information from an external media API.
/// </summary>
/// <remarks>
/// This class is responsible for searching person-related media information using specific query filters such as name, adult content inclusion, language preferences, and pagination.
/// It extends the <see cref="VideoEndpoint{TMedia}"/> base class, implementing functionality to populate and clear search-specific parameters.
/// </remarks>
public class SearchPersonInformation : VideoEndpoint<Person>
{
    // Filter Options
    public string? Query { get; set; }
    
    public bool? IncludeAdult {get; set;}
    
    public string? Language {get; set;}
    
    public int? Page {get; set;}
    
    public SearchPersonInformation() : base ("https://api.themoviedb.org/3/search/person")
    {}

    public override void PopulateParameters()
    {
        ClearParametersString();
        if (Query != null)
        {
            Parameters = $"query={Query}";
        }

        if (IncludeAdult != null)
        {
            Parameters = $"include_adult={IncludeAdult}";
        }

        if (Language != null)
        {
            Parameters = $"language={Language}";
        }

        if (Page != null)
        {
            Parameters = $"page={Page}";
        }
    }

    public override void EmptyParameters()
    {
        ClearParametersString();
        Query = null;
        IncludeAdult = null;
        Language = null;
        Page = null;
    }
}