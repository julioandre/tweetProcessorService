namespace tweetProcessor.Models;

public class FollowEntity
{
    public string followeeId { get; set; }
    
    public string followerId { get; set; }
    
    public DateTime followDate { get; set; }
}