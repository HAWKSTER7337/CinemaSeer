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
public class DiscoverMoviesInformationEndpoint : MediaEndpoint<Movie>
{
    private const string EndPointString = "https://api.themoviedb.org/3/discover/movie";

    public DiscoverMoviesInformationEndpoint() : base(EndPointString)
    {
        Parameters = null; 
    }
}