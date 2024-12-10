using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an endpoint for discovering TV show information from the TheMovieDB API.
/// </summary>
/// <remarks>
/// Inherits the <see cref="MediaEndpoint"/> class to provide a specialized implementation for retrieving TV show data.
/// Utilizes RESTful requests to fetch data by making use of a specific API endpoint URL.
/// </remarks>
public class DiscoverTvShowInformationEndpoint : MediaEndpoint<TvShow>
{
    private const string EndpointString = "https://api.themoviedb.org/3/discover/tv";

    public DiscoverTvShowInformationEndpoint() : base(EndpointString)
    {
        Parameters = null;
    }
}