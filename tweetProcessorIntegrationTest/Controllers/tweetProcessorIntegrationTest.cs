using System.Net;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using tweetProcessor.Models;

namespace tweetProcessorIntegrationTest.Controllers;

public class tweetProcessorIntegrationTest:IDisposable
{
    private CustomWebApplicationFactory _factory;
    private HttpClient _client;

    public tweetProcessorIntegrationTest()
    {
        _factory = new CustomWebApplicationFactory();
        _client = new HttpClient();
    }

    public void Dispose()
    {
        _factory.Dispose();
        _client.Dispose();
    }

    [Fact]
    public async Task PopulateTimeline_returnsOk()
    {
        var users = new List<String>(){"001dc4b4-6372-4d2b-af60-2b588d7b8f07",
            "00a7bca3-ce62-4809-bbfe-9a7c5152ced7",
            "050de526-2171-41b3-a49e-33a03798e807",
            "05c6573f-0e08-4015-abd9-1ae99d01676a",
            "05e553aa-1e5f-42ca-aa11-fca7cb9e0554",
            "06ea270b-10d2-4bc4-9b01-8fbdf156695d",
            "079e9702-c074-4efe-a39e-32a2ceae9a6d",
            "07e8fde5-49cf-471d-86e7-042f59b34519",
            "09810aef-1c94-4674-8df2-5c42e301d362",
            "09ff49da-0f9b-46b4-bb51-76067dcbb891"};
        var tweet = new Tweet(Guid.NewGuid().ToString(), "1343b6a3-4bbd-459d-afbc-f1d15b2c43c8", DateTime.Now,
            "Messy Tweeet Processor", "Image.url");

        var processor = new ProcessorDTO()
        {
            followers = users, tweet = tweet
        };
        var response = await _client.PostAsync("http://localhost:5106/api/tweetProcessor/populateTimeline", JsonContent.Create(processor));
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task PopulateTimelineByID_returnsOk()
    {
        var id = "001dc4b4-6372-4d2b-af60-2b588d7b8f07";
        
        var response = await _client.GetAsync($"http://localhost:5106/api/tweetProcessor/populateTimeline/{id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}