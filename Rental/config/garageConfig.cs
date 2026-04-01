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
        builder.HasOne<GarageType>(g => g.GarageType).WithMany().HasForeignKey(g => g.TypeId);
    }
}