using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

/// <summary>
/// Represents an API endpoint for retrieving movie poster images in the form of byte data.
/// This class is used to fetch and process movie poster images from the TMDB image API.
/// </summary>
/// <remarks>
/// This endpoint constructs a request URL with the base TMDB image URL and any specified parameters.
/// The information is then processed into a MoviePoster object containing raw image bytes.
/// </remarks>
public class GetImageEndpoint : MediaEndpoint<Poster>
{
    protected override string FullRequestUrl => $"{BaseEndpointUrl}{Parameters}";
    
    public GetImageEndpoint() : base("https://image.tmdb.org/t/p/original/")
    {}

    protected override Poster ProcessResponse(RestResponse response)
    {
        try
        {
            if (response is { IsSuccessful: false, RawBytes: null }) throw new Exception("Request was not successful");
            var movieImage = new Poster(response.RawBytes);
            return movieImage;
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while processing an image", e);
        }
    }
}