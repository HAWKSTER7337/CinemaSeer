using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Abstract class representing a movie information endpoint.
/// </summary>
/// <remarks>
/// This class serves as a base for creating specific movie information endpoints.
/// It manages the construction of the full request URL using a base endpoint URL and optional parameters.
/// The class also handles sending HTTP requests and processing the responses.
/// </remarks>
public abstract class MediaEndpoint
{
    protected readonly string ApiAuthorizationKey = GetApiAuthorizationKey();
    
    private readonly string _baseEndpointUrl;

    protected string? Parameters;
    protected string FullRequestUrl => Parameters != null ? $"{_baseEndpointUrl}?{Parameters}" : _baseEndpointUrl;

    protected MediaEndpoint(string baseEndpointUrl)
    {
        _baseEndpointUrl = baseEndpointUrl;
    }
    
    protected async Task<TResultType> SendRequest<TResultType>(RestClient client, RestRequest request)
    {
        try
        {
            var response = await client.GetAsync(request);
            return ProcessResponse<TResultType>(response);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while fetching media", ex);
        }
    }

    private TResultType ProcessResponse<TResultType>(RestResponse response)
    {
        if (response.IsSuccessful)
        {
            var movieResponse = JsonSerializer.Deserialize<TResultType>(response.Content);
            return movieResponse ?? throw new Exception("Failed to deserialize movie data");
        }

        throw new Exception("Request was not successful");
    }

    private static string GetApiAuthorizationKey()
    {
        var apiKey = Environment.GetEnvironmentVariable("MOVIE_API_KEY");
        return apiKey ?? throw new NullReferenceException("API key was not found in environment variables");
    }
    
    public abstract Task<TResultType> GetInformation<TResultType>();
}