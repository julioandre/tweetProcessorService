namespace tweetProcessor.Models;

public class ProcessorDTO
{
    public IList<string> followers { get; set; }
    public Tweet tweet { get; set; } }