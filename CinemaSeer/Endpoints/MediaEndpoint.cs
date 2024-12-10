using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an abstract base class for media-related endpoints that interact with external APIs.
/// </summary>
/// <remarks>
/// This class provides the foundational functionality for constructing and sending HTTP requests to
/// media endpoints. It includes mechanisms for setting up the base URL, handling request parameters,
/// and processing API responses. Derived classes must implement the <see cref="GetInformationAsync"/>
/// method to retrieve specific media information based on their context.
/// </remarks>
public abstract class MediaEndpoint<TMedia> where TMedia : class, IMedia
{
    private readonly string ApiAuthorizationKey = GetApiAuthorizationKey();
    
    private readonly string _baseEndpointUrl;

    protected string? Parameters;
    
    private string FullRequestUrl => Parameters != null ? $"{_baseEndpointUrl}?{Parameters}" : _baseEndpointUrl;

    protected MediaEndpoint(string baseEndpointUrl)
    {
        _baseEndpointUrl = baseEndpointUrl;
    }

    private static async Task<TResultType> SendRequest<TResultType>(RestClient client, RestRequest request)
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

    private static TResultType ProcessResponse<TResultType>(RestResponse response)
    {
        try
        {
            if (!response.IsSuccessful) throw new Exception("Request was not successful");
            var movieResponse = JsonSerializer.Deserialize<TResultType>(response.Content);
            return movieResponse ?? throw new Exception("Failed to deserialize movie data");
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while processing media", ex);
        }
    }

    private static string GetApiAuthorizationKey()
    {
        var apiKey = Environment.GetEnvironmentVariable("MOVIE_API_KEY");
        return apiKey ?? throw new NullReferenceException("API key was not found in environment variables");
    }
    
    public async Task<MediaResponse<TMedia>> GetInformationAsync()
    {
        var options = new RestClientOptions(FullRequestUrl);
        var client = new RestClient(options);
        var request = new RestRequest("");
        
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", ApiAuthorizationKey);
        
        var response = await SendRequest<MediaResponse<TMedia>>(client, request);
        return response;
    }
}