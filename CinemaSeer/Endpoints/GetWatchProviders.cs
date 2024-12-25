using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// GetWatchProviders is an endpoint class responsible for acquiring watch provider information
/// for a specific media item from an external API.
/// This class extends the MediaEndpoint class to process watch provider-related data.
/// </summary>
public class GetWatchProviders : MediaEndpoint<WatchProviders>
{
    public MediaItem? mediaItem { get; set; }
    
    public string UpdatedBaseEndpointURL => $"https://api.themoviedb.org/3/{mediaItem.TypeOfMedia}/{mediaItem.Id}/watch/providers";
    
    public GetWatchProviders() : base("")
    {}

    protected override WatchProviders ProcessResponse(RestResponse response)
    {
        try
        {
            if (!response.IsSuccessful) throw new Exception(response.ErrorMessage);
            var watchProviders = JsonSerializer.Deserialize<WatchProviders>(response.Content);
            
            if (watchProviders == null || mediaItem == null)
            {
                throw new Exception("Failed to deserialize watch providers response");
            }
            
            watchProviders.nameOfMovie = mediaItem.Title;
            return watchProviders;
        }
        catch(Exception ex)
        {
            throw new Exception("An error occured while trying to get the provider list", ex);
        }
    }

    public override async Task<WatchProviders> GetInformationAsync()
    {
        if (mediaItem == null) throw new Exception("No Media Item has been set to get the watch provider");
        SetUpAPICall();
        return await base.GetInformationAsync();
    }

    private void SetUpAPICall()
    {
        BaseEndpointUrl = UpdatedBaseEndpointURL;
    }
}