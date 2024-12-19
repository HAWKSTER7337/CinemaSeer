using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;
using System.IO;

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
public abstract class VideoEndpoint<TMedia> : MediaEndpoint<MediaResponse<TMedia>>, IFilter where TMedia : class, IMedia
{

    protected VideoEndpoint(string baseEndpointUrl) : base(baseEndpointUrl)
    {}

    protected override MediaResponse<TMedia> ProcessResponse(RestResponse response)
    {
        try
        {
            if (response is { IsSuccessful: false, RawBytes: null }) throw new Exception("Request was not successful");
            var movieResponse = JsonSerializer.Deserialize<MediaResponse<TMedia>>(response.Content);
            return movieResponse ?? throw new Exception("Failed to deserialize movie data");
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while processing media", ex);
        }
    }

    public override async Task<MediaResponse<TMedia>> GetInformationAsync()
    {
        PopulateParameters();
        return await base.GetInformationAsync();
    }

    public abstract void PopulateParameters();

    public abstract void EmptyParameters();
}