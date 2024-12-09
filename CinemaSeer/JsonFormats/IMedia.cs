namespace CinemaSeer.JsonFormats;

public interface IMedia
{
    public MediaItem GetInfo();

    public string ToBasicDataString();
}