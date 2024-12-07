namespace CinemaSeer;

public class Program
{
    public static async Task Main(string[] args)
    {
        var movieInformation = new MovieInformationEndpoint();
        await movieInformation.Test();
    }
}