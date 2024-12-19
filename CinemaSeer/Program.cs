using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;


namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Getting all discover Movies
        var movieInformation = new DiscoverMoviesInformationEndpoint();
        movieInformation.Year = 2024;
        movieInformation.Page = 100;
        movieInformation.SortBy = SortByEnum.TitleDesc;
        var response = await movieInformation.GetInformationAsync();

        // Getting all discover TV Shows
        var tvShowInformation = new DiscoverTvShowInformationEndpoint();
        tvShowInformation.Page = 1;
        tvShowInformation.SortBy = SortByEnum.OriginalTitleAsc;
        var response2 = await tvShowInformation.GetInformationAsync();
        
        // Merging lists
        var fullList = new List<IMedia>();
        fullList.AddRange(response.Results);
        fullList.AddRange(response2.Results);
    
        // storing all the media into media items
        var mediaItems = new List<MediaItem>();
        fullList.ForEach(item => mediaItems.Add(item.GetInfo()));

        // Displaying Data that has been collected
        foreach (var media in mediaItems)
        {
            Console.WriteLine(media.ToString());
        }
    }
}