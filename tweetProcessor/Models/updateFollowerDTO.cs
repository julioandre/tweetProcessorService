namespace tweetProcessor.Models;

public class updateFollowerDTO
{
    public Tweet tweet { get; set; }
    public IList<FollowEntity> followData {get; set;}

    public updateFollowerDTO(Tweet tweet, IList<FollowEntity> follow)
    {
        this.tweet = tweet;
        this.followData = follow;
    }
}