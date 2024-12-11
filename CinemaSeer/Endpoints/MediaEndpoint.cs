using System.ComponentModel.Design;
using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents a base class for accessing specific media-related API endpoints.
/// This class provides a general structure to send requests to an API and process responses.
/// </summary>
/// <typeparam name="TMedia">The type of media data returned by the endpoint.</typeparam>
public abstract class MediaEndpoint<TMedia>
{
    private readonly string _apiAuthorizationKey = GetApiAuthorizationKey();
    
    protected string BaseEndpointUrl { get; private set; }

    public string? Parameters { get; set; }
    
    protected virtual string FullRequestUrl => Parameters != null ? $"{BaseEndpointUrl}?{Parameters}" : BaseEndpointUrl;
    
    protected abstract TMedia ProcessResponse(RestResponse response);

    protected MediaEndpoint(string baseEndpointUrl) => BaseEndpointUrl = baseEndpointUrl;

    private async Task<TMedia> SendRequest(RestClient client, RestRequest request)
    {
        try
        {
            var response = await client.GetAsync(request);
            return ProcessResponse(response);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while fetching media", ex);
        }
    }
    
    public async Task<TMedia> GetInformationAsync()
    {
        var options = new RestClientOptions(FullRequestUrl);
        var client = new RestClient(options);
        var request = new RestRequest("");
        
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", _apiAuthorizationKey);
        
        var response = await SendRequest(client, request);
        return response;
    }
    
    private static string GetApiAuthorizationKey()
    {
        var apiKey = Environment.GetEnvironmentVariable("MOVIE_API_KEY");
        return apiKey ?? throw new NullReferenceException("API key was not found in environment variables");
    }
    
    
}