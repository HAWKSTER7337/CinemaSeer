using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an endpoint for discovering TV show information from the TheMovieDB API.
/// </summary>
/// <remarks>
/// Inherits the <see cref="MediaEndpoint"/> class to provide a specialized implementation for retrieving TV show data.
/// Utilizes RESTful requests to fetch data by making use of a specific API endpoint URL.
/// </remarks>
public class DiscoverTvShowInformationEndpoint : MediaEndpoint
{
    private const string EndpointString = "https://api.themoviedb.org/3/discover/tv";
        
    public DiscoverTvShowInformationEndpoint() : base(EndpointString)
    {}

    public override async Task<TVShowResponse> GetInformation<TVShowResponse>()
    {
        var options = new RestClientOptions(EndpointString);
        var client = new RestClient(options);
        var request = new RestRequest("");
        
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", ApiAuthorizationKey);
        
        var response = await SendRequest<TVShowResponse>(client, request);
        return response;
    }
}