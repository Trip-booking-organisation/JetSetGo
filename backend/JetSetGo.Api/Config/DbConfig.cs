using JetSetGo.Infrastructure.Persistence;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace backend.Config;

public static class DbConfig
{
    public static async void RunCosmosCreation(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<JetSetGoContext>();
        var cosmosClient = context?.Database.GetCosmosClient();
        await cosmosClient?.CreateDatabaseIfNotExistsAsync("jet-set-go")!;
        var db = cosmosClient.GetDatabase("jet-set-go")!;
        var containerProperties = new ContainerProperties
        {
            Id = "Flights",
            PartitionKeyPath = "/pk",
            IndexingPolicy = new IndexingPolicy
            {
                Automatic = false,
                IndexingMode = IndexingMode.Lazy,
            }
        };
        var containerProperties1 = new ContainerProperties
        {
            Id = "Users",
            PartitionKeyPath = "/pk",
            IndexingPolicy = new IndexingPolicy
            {
                Automatic = false,
                IndexingMode = IndexingMode.Lazy,
            }
        };
        await db.CreateContainerIfNotExistsAsync(containerProperties,
            ThroughputProperties.CreateAutoscaleThroughput(10000));
    }
}