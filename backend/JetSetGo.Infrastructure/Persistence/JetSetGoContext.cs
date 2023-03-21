using JetSetGo.Domain.Flights;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class JetSetGoContext : DbContext
{

    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.Load();
        DotNetEnv.Env.TraversePath().Load();
        var accountEndpoint = Environment.GetEnvironmentVariable("DB_ACC_ENDPOINT") ?? "https://localhost:8081";
        var accKey=Environment.GetEnvironmentVariable("DB_ACC_KEY") ?? "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        var dbName=Environment.GetEnvironmentVariable("DB_NAME") ?? "jet-set-go";
        optionsBuilder.UseCosmos(
            accountEndpoint,
            accKey, dbName);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>().ToContainer("Flights");
        modelBuilder.Entity<User>().ToContainer("Users");
        modelBuilder.Entity<Flight>()
            .HasPartitionKey(f => f.Id);
        modelBuilder.Entity<Flight>()
            .OwnsMany(f => f.Tickets);
        modelBuilder.Entity<User>()
            .HasPartitionKey(u => u.Id);
    }
}