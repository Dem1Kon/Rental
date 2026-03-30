using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class GarageConfig : IEntityTypeConfiguration<Garage>
{
    public void Configure(EntityTypeBuilder<Garage> builder)
    {
        builder.ToTable("Garages");
        builder.HasKey(v => v.Id);
        builder.HasMany(g => g.Vehicles).WithOne().HasForeignKey(v => v.GarageId);
        builder.Property(g => g.Name).HasMaxLength(50).IsRequired();
    }
}