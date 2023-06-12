using StackExchange.Redis;

namespace tweetProcessor.Config;

public class ConnectionHelper2
{
    static ConnectionHelper2() {
        ConnectionHelper2.lazyConnection = new Lazy <ConnectionMultiplexer> (() => {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisUrl2"]);
        });
    }
    private static Lazy <ConnectionMultiplexer> lazyConnection;
    public static ConnectionMultiplexer Connection {
        get {
            return lazyConnection.Value;
        }
    }
}