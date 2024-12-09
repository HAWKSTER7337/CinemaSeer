using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;

namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        var movieInformation = new DiscoverMediaInformationEndpoint();
        var response = await movieInformation.GetInformation<MediaResponse>();

        // var tvShowInformation = new DiscoverTvShowInformationEndpoint();
        // var response2 = await tvShowInformation.GetInformation<MediaResponse>();
        
        //response.MergeAnotherMediaResponseIntoThisOne(response2);
        
        var mediaItems = response.Results.Select(movie => movie.GetInfo()).ToList();
        mediaItems.ForEach(mediaItem => Console.WriteLine(mediaItem));
    }
}