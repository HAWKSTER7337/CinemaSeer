using CinemaSeer.Endpoints;
using CinemaSeer.JsonFormats;


namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        await TestingLoop();
    }

    private static async Task TestingLoop()
    {
        var usersChoice = -1;
        while (usersChoice != 4)
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine(
                "Please Select an option:\n" +
                "1. Search Movie Information\n" +
                "2. Search Tv Show Information\n" +
                "3. Search Person Information\n" +
                "4. Exit"
                );
            usersChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\n\n\n\n");

            if (usersChoice == 1)
            {
                var searchMovie = new SearchMovieInformation();
                Console.WriteLine("What is the Movie you are looking to find?");
                searchMovie.Query = Console.ReadLine();
                var movieResults = await searchMovie.GetInformationAsync();
                var watchProviders = new GetWatchProviders();
                foreach (var movie in movieResults.Results)
                {
                    watchProviders.mediaItem = movie.GetInfo();
                    var placesToWatch = await watchProviders.GetInformationAsync();
                    Console.WriteLine(movie.ToBasicDataString());
                    Console.WriteLine(placesToWatch.GetUSPlacesToStream());
                }
            }

            else if (usersChoice == 2)
            {
                var SeachTvShows = new SearchTvShowInformation();
                Console.WriteLine("What is the Tv Show you are looking to find?");
                SeachTvShows.Query = Console.ReadLine();
                var tvShowSearchResults = await SeachTvShows.GetInformationAsync();
                var watchProviders = new GetWatchProviders();
                foreach (var tvShow in tvShowSearchResults.Results)
                {
                    watchProviders.mediaItem = tvShow.GetInfo();
                    var placesToWatch = await watchProviders.GetInformationAsync();
                    Console.WriteLine(tvShow.ToBasicDataString());
                    Console.WriteLine(placesToWatch.GetUSPlacesToStream());
                }
            }

            else if (usersChoice == 3)
            {
                var personInfoSearch = new SearchPersonInformation();
                Console.WriteLine("Who is the actor you are looking to find?");
                personInfoSearch.Query = Console.ReadLine();
                var personSearchResults = await personInfoSearch.GetInformationAsync();
                personSearchResults.Results.ForEach(person => Console.WriteLine(person.ToBasicDataString()));
            }
            
            else if (usersChoice == 4)
            {
                Console.WriteLine("Exiting...");
                break;
            }

            else
            {
                Console.WriteLine("Not a proper input please try again...");
            }
        }
    }
}