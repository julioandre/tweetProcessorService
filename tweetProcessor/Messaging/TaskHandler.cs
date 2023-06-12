using AutoMapper;
using Confluent.Kafka;
using KafkaFlow.Producers;
using Newtonsoft.Json;
using tweetProcessor.Cache;
using tweetProcessor.Models;

namespace tweetProcessor.Messaging;

public class TaskHandler:ITaskHandler
{
     private readonly ILogger<string> _logger;
    //private IProducerAccessor _producer;
    private readonly string bootstrapServers = "127.0.0.1:9092";
    private ICacheService _cacheService;
    private readonly IMapper _mapper;

    public TaskHandler(ILogger<string> logger, IMapper mapper, ICacheService cacheService)
    {
        _logger = logger;
        _mapper = mapper;
        //_producer = producerAccessor;
        _cacheService = cacheService;

    }
    public async Task HandleTweets(CancellationToken stoppingToken)
    {
        
        string topic = "tweetProcessorTopic";
        string groupId = "processor_group";
        string followerId;
        IList<string> followeeList = new List<string>();
        var config = new ConsumerConfig {GroupId = groupId, BootstrapServers = bootstrapServers, AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest};
        try
        {
            using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumerBuilder.Subscribe(topic);
                
                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Starting to Consume");
                        var consumer = consumerBuilder.Consume(stoppingToken);
                        var orderRequest = JsonConvert.DeserializeObject<tweetProcessorDTO>(consumer.Message.Value);
                        Console.WriteLine("Consuming");
                        
                        //var followees1 = JsonConvert.DeserializeObject<List<FollowEntity>>(followees.ToList());

                        foreach (var item in orderRequest.followeeTweets)
                        {
                            _cacheService.SetTimeline(orderRequest.UserID, item);
                        }

                    }
                    
                }catch (OperationCanceledException) {
                    consumerBuilder.Close();
                }
            }
        
        }catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }
    public async Task HandleSingleTweets(CancellationToken stoppingToken)
    {
        
        string topic = "ProcessorTopic";
        string groupId = "processTL_group";
        string followerId;
        IList<string> followerList = new List<string>();
        var config = new ConsumerConfig {GroupId = groupId, BootstrapServers = bootstrapServers, AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest};
        try
        {
            using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumerBuilder.Subscribe(topic);
                
                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Starting to Consume");
                        var consumer = consumerBuilder.Consume(stoppingToken);
                        var orderRequest = JsonConvert.DeserializeObject<updateFollowerDTO>(consumer.Message.Value);
                        Console.WriteLine("Consuming");
                        
                        //var followees1 = JsonConvert.DeserializeObject<List<FollowEntity>>(followees.ToList());

                        foreach (var item in orderRequest.followData)
                        {
                            _cacheService.SetTimeline(item.followerId, orderRequest.tweet);
                        }

                    }
                    
                }catch (OperationCanceledException) {
                    consumerBuilder.Close();
                }
            }
        
        }catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }
}