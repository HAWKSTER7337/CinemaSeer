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
    public DiscoverTvShowInformationEndpoint() : base("https://api.themoviedb.org/3/discover/tv")
    {
        Parameters = null;
    }
}