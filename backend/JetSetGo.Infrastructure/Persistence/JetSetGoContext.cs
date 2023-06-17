using JetSetGo.Domain.ApiKeys;
using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Users;
using JetSetGo.Domain.Tickets;
using JetSetGo.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class JetSetGoContext : DbContext
{

    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<ApiKey> ApiKeys { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.Load();
        DotNetEnv.Env.TraversePath().Load();
        var accountEndpoint = Environment.GetEnvironmentVariable("DB_ACC_ENDPOINT") ?? "https://jet-set-go.documents.azure.com:443/";
        var accKey = Environment.GetEnvironmentVariable("DB_ACC_KEY")!;
        var dbName=Environment.GetEnvironmentVariable("DB_NAME") ?? "jet-set-go";

        optionsBuilder.
            UseCosmos(
            accountEndpoint,
            accKey, dbName);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>().ToContainer(nameof(Flights));
        modelBuilder.Entity<Ticket>().ToContainer(nameof(Tickets));
        modelBuilder.Entity<User>().ToContainer(nameof(Users));
        modelBuilder.Entity<ApiKey>().ToContainer(nameof(ApiKeys));

        var flightEntity = modelBuilder.Entity<Flight>();
        flightEntity.HasPartitionKey(f => f.Id);
        flightEntity.OwnsMany(f => f.Seats);
        flightEntity.OwnsOne(f => f.Departure, 
                builder =>
                {
                    builder.OwnsOne(a => a.Address);
                    builder.Property(x => x.Date)
                        .HasConversion(new DateConverter());
                    builder.Property(x => x.Time)
                        .HasConversion(new DateTimeConverter());
                });
        flightEntity.OwnsOne(f => f.Arrival, 
                builder =>
                {
                    builder.OwnsOne(a => a.Address);
                    builder.Property(x => x.Date)
                        .HasConversion(new DateConverter());
                    builder.Property(x => x.Time)
                        .HasConversion(new DateTimeConverter());
                });


        modelBuilder.Entity<User>()
            .HasPartitionKey(u => u.Id);

        modelBuilder.Entity<Ticket>()
            .HasPartitionKey(t => t.Id);
        modelBuilder.Entity<ApiKey>()
            .HasPartitionKey(a => a.Id);
    }
}