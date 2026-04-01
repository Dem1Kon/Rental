using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class GarageTypesConfig : IEntityTypeConfiguration<GarageType>
{
    public void Configure(EntityTypeBuilder<GarageType> builder)
    {
        builder.ToTable("GarageTypes");
        builder.HasKey(x => x.Id);
        builder.HasData(
            new GarageType { Id = 1, Name = "Small Garage", Capacity = 5, Price = 10000, Costs = 1000 },
            new GarageType { Id = 2, Name = "Medium Garage", Capacity = 15, Price = 20000, Costs = 4000 },
            new GarageType { Id = 3, Name = "Large Garage", Capacity = 30, Price = 50000, Costs = 10000 }
        );
    }
}