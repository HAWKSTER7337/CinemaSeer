using RestSharp;

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
public class DiscoverMediaInformationEndpoint : MediaEndpoint
{
    private const string EndPointString = "https://api.themoviedb.org/3/discover/movie";

    public DiscoverMediaInformationEndpoint() : base(EndPointString)
    {
        Parameters = null;
    }

    public override async Task<TMovieResponse> GetInformation<TMovieResponse>()
    {
        var options = new RestClientOptions(FullRequestUrl);
        var client = new RestClient(options);
        var request = new RestRequest("");
        
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", ApiAuthorizationKey);
        
        var response = await SendRequest<TMovieResponse>(client, request);
        return response;
    }
}