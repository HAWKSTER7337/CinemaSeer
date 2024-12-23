using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;


namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        var movieSearch = new SearchMovieInformation();
        movieSearch.Query = "Lord of The Rings ";
        var response = await movieSearch.GetInformationAsync();

        var tvShowSearch = new SearchTvShowInformation();
        tvShowSearch.Query = "Stranger Things";
        var response2 = await tvShowSearch.GetInformationAsync();

        var fullList = new List<IMedia>();
        fullList.AddRange(response2.Results);
        
        // Getting the places to watch the movies
        var watchProviders = new GetWatchProviders();
        foreach (var video in fullList)
        {
            watchProviders.mediaItem = video.GetInfo();
            var placeToWatch = await watchProviders.GetInformationAsync();
            Console.WriteLine(placeToWatch.GetUSPlacesToStream());
        }
    }
}