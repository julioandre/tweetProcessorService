using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace tweetProcessorIntegrationTest.Controllers;

public class CustomWebApplicationFactory:WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
       

        builder.UseEnvironment("Development");
    }
}