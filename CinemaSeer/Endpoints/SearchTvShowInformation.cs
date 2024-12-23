using CinemaSeer.JsonFormats;

namespace CinemaSeer.Endpoints;

public class SearchTvShowInformation : VideoEndpoint<TvShow>
{
    // Filter Options 
    public string? Query { get; set; }
    
    public int? FirstAirDateYear { get; set; }
    
    public bool? IncludeAdult { get; set; }
    
    public string? Language { get; set; }
    
    public int? Page { get; set; }
    
    public int? Year { get; set; }
    
    public SearchTvShowInformation() : base("https://api.themoviedb.org/3/search/tv")
    {}

    public override void PopulateParameters()
    {
        ClearParametersString();
        if (Query != null)
        {
            Parameters = $"query={Query}";
        }

        if (FirstAirDateYear != null)
        {
            Parameters = $"first_air_date_year={FirstAirDateYear}";
        }

        if (Language != null)
        {
            Parameters = $"language={Language}";
        }

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
    }
    
    public override void EmptyParameters()
    {
        ClearParametersString();
        Page = null;
        Year = null;
        Query = null;
        Language = null;
        FirstAirDateYear = null;
        IncludeAdult = null;
    }
}