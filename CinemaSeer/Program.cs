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
    
        // storing all the media into media items
        var mediaItems = new List<MediaItem>();
        fullList.ForEach(item => mediaItems.Add(item.GetInfo()));
        
        // Storing all the images inside of the image data
        var getImageEndpoint = new GetImageEndpoint();
        foreach (var media in mediaItems)
        {
            getImageEndpoint.Parameters = media.PosterFileLocation;
            media.Poster = await getImageEndpoint.GetInformationAsync();
        }

        var imageLoader = new ImageLoader();

        foreach (var item in mediaItems.Where(item => item.Title == "Deadpool & Wolverine"))
        {
            imageLoader.LoadImageInGallary(item.Poster.RawBytes);
        }
        
        Console.WriteLine("Press any button to exit the program");
        Console.ReadKey();
        imageLoader.RemoveAllCreatedJpegFiles();
    }
}