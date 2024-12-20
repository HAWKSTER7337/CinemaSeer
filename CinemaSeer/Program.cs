using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;


namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        // // Getting all discover Movies
        // var movieInformation = new DiscoverMoviesInformationEndpoint();
        // var response = await movieInformation.GetInformationAsync();
        //
        // // Getting all discover TV Shows
        // var tvShowInformation = new DiscoverTvShowInformationEndpoint();
        // var response2 = await tvShowInformation.GetInformationAsync();
        //
        // // Merging lists
        // var fullList = new List<IMedia>();
        // fullList.AddRange(response.Results);
        // fullList.AddRange(response2.Results);

        var movieSearch = new SearchMovieInformation();
        movieSearch.Query = "Lord of The Rings";
        var response = await movieSearch.GetInformationAsync();

        var fullList = new List<IMedia>();
        fullList.AddRange(response.Results);
        
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