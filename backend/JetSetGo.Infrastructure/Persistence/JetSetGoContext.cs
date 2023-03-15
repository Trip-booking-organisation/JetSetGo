using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class JetSetGoContext : DbContext
{

    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.Load();
        var accountEndpoint = Environment.GetEnvironmentVariable("DB_ACC_ENDPOINT") ?? "https://jetsetgo.documents.azure.com:443/";
        var accKey=Environment.GetEnvironmentVariable("DB_ACC_KEY")!;
        var dbName=Environment.GetEnvironmentVariable("DB_NAME") ?? "letsetgo-db";
        optionsBuilder.UseCosmos(
            accountEndpoint,
            accKey,
            dbName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>()
            .ToContainer("Flights")
            .HasPartitionKey(f => f.Id);
        modelBuilder.Entity<Flight>().OwnsMany(f => f.Tickets);

        modelBuilder.Entity<User>()
            .ToContainer("Users")
            .HasPartitionKey(u => u.Id);
    }
}