using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;

namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Getting all discover Movies
        var movieInformation = new DiscoverMoviesInformationEndpoint();
        var response = await movieInformation.GetInformationAsync();

        // Getting all discover TV Shows
        var tvShowInformation = new DiscoverTvShowInformationEndpoint();
        var response2 = await tvShowInformation.GetInformationAsync();
        
        // Merging lists
        var fullList = new List<IMedia>();
        fullList.AddRange(response.Results);
        fullList.AddRange(response2.Results);

        var mediaItems = new List<MediaItem>();
        fullList.ForEach(item => mediaItems.Add(item.GetInfo()));

        var imageParam = mediaItems[1].PosterFileLocation;
        var getImageEndpoint = new GetImageEndpoint();
        getImageEndpoint.Parameters = imageParam;
        var testingImage = await getImageEndpoint.GetInformationAsync();
        Console.WriteLine(testingImage.ToString());
    }
}