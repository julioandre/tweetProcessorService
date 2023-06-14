using tweetProcessor.Cache;
using tweetProcessor.Messaging;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ICacheService, CacheService>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ITaskHandler, TaskHandler>();
        builder.Services.AddHostedService<Consumer>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddStackExchangeRedisCache(options =>
        {
    
            options.Configuration = "localhost:6377";
            options.InstanceName = "timeline-redis-cache";
   
        });
        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}