using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;

namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        var movieInformation = new DiscoverMovieInformationEndpoint();
        var response = await movieInformation.GetInformation<MovieResponse>();
        var mediaItems = response.Results.Select(movie => movie.GetInfo()).ToList();
        mediaItems.ForEach(mediaItem => Console.WriteLine(mediaItem));
    }
}