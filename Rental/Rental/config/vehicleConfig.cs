using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");
        builder.HasKey(v => v.Id);
        builder.HasOne(v => v.Storage).WithMany(g => g.Vehicles).HasForeignKey(v => v.StorageId);
        builder.HasOne(v => v.Type).WithMany().HasForeignKey(v => v.TypeId);
    }
}