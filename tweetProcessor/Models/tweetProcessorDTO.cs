namespace tweetProcessor.Models;

public class tweetProcessorDTO
{
    public string UserID{get; set;}
    public IList<Tweet> followeeTweets{get; set;}
}