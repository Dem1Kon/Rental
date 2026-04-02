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
            new VehicleType { Id = 1, Name = "Economy Car", Category = "Car", Level = "Economy", Price = 5000, MonthlyIncome = 500, RequiredStorageType = "Garage" },
            new VehicleType { Id = 2, Name = "Comfort Car", Category = "Car", Level = "Comfort", Price = 10000, MonthlyIncome = 1000, RequiredStorageType = "Garage" },
            new VehicleType { Id = 3, Name = "Business Car", Category = "Car", Level = "Business", Price = 20000, MonthlyIncome = 3000, RequiredStorageType = "Garage"}
            );
    }
}