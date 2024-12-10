namespace CinemaSeer.JsonFormats;

public class MoviePoster
{
    public byte[]? RawBytes { get; private set; }

    public MoviePoster(byte[]? rawBytes)
    {
        RawBytes = rawBytes;
    }
}