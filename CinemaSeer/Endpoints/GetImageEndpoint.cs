using System.Text.Json;
using CinemaSeer.JsonFormats;
using RestSharp;

namespace CinemaSeer.Endpoints;

public class GetImageEndpoint : MediaEndpoint<MoviePoster>
{
    protected override string FullRequestUrl => $"{BaseEndpointUrl}{Parameters}";
    
    public GetImageEndpoint() : base("https://image.tmdb.org/t/p/original/")
    {}

    protected override MoviePoster ProcessResponse(RestResponse response)
    {
        try
        {
            if (response is { IsSuccessful: false, RawBytes: null }) throw new Exception("Request was not successful");
            var movieImage = new MoviePoster(response.RawBytes);
            return movieImage;
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while processing an image", e);
        }
    }

    public void SetParameters(string imageURl)
    {
        Parameters = imageURl;
    }
}