using RestSharp;

namespace CinemaSeer;

public class MovieInformationEndpoint
{
    public MovieInformationEndpoint() {}

    public async Task Test()
    {
        var options = new RestClientOptions("https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4ZmE4ZDI2YjU0M2UxNGUzNWVjNDM3NWEyYjc2OWJlZiIsIm5iZiI6MTczMzYwODc0My44MDgsInN1YiI6IjY3NTRjNTI3ZmRiYTkzOGU4NjM2NTY0OCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.gfuNbZFAY6BUFUoGyaK7bCMnADNMlkWfZ43EJkmTDv4");
        var response = await client.GetAsync(request);
        
        Console.WriteLine("{0}", response.Content);
    }
}