namespace CinemaSeer.JsonFormats;

public class Poster
{
    public byte[]? RawBytes { get; private set; }

    public Poster(byte[]? rawBytes)
    {
        RawBytes = rawBytes;
    }
}