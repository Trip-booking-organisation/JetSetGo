using JetSetGo.Domain;
using JetSetGo.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure;

public class JetSetGoContext : DbContext
{
    public DbSet<Flight>? Flights { get; set; }
    public DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            "",
            "",
            "");
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