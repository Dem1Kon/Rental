using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class VehicleTypesConfig : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.ToTable("VehicleTypes");
        builder.HasKey(x => x.Id);
        builder.HasData(
            new VehicleType { Name = "Economy Car", Category = "Car", Level = "Economy", Price = 5000, Income = 500 },
            new VehicleType { Name = "Comfort Car", Category = "Car", Level = "Comfort", Price = 10000, Income = 1000 },
            new VehicleType { Name = "Business Car", Category = "Car", Level = "Business", Price = 20000, Income = 3000 }
            );
    }
}