using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Tickets;
using JetSetGo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class JetSetGoContext : DbContext
{

    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.Load();
        DotNetEnv.Env.TraversePath().Load();
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
        modelBuilder.Entity<Flight>().ToContainer("Flights");
        modelBuilder.Entity<Ticket>().ToContainer("Tickets");
        modelBuilder.Entity<User>().ToContainer("Users");
        
        modelBuilder.Entity<Flight>()
            .HasPartitionKey(f => f.Id);
        modelBuilder.Entity<Flight>()
            .OwnsMany(f => f.Seats);

        modelBuilder.Entity<User>()
            .HasPartitionKey(u => u.Id);
        
        modelBuilder.Entity<Ticket>()
            .HasPartitionKey(t => t.Id);
    }
}