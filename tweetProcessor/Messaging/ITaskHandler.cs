namespace tweetProcessor.Messaging;

public interface ITaskHandler
{
    public  Task HandleTweets( CancellationToken stoppingToken);
}