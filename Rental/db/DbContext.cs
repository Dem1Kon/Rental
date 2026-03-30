using Microsoft.EntityFrameworkCore;
using Rental.config;
using Rental.models;

namespace Rental.db;

public class Context : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Garage> Garages { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=CarRentalGame;Username=postgres;Password=!Dem1Kon");
        ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VehicleConfig());
        modelBuilder.ApplyConfiguration(new CompanyConfig());
        modelBuilder.ApplyConfiguration(new GarageConfig());
    }
}