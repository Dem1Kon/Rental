using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class StorageTypesConfig : IEntityTypeConfiguration<StorageType>
{
    public void Configure(EntityTypeBuilder<StorageType> builder)
    {
        builder.ToTable("StorageTypes");
        builder.HasKey(x => x.Id);
        builder.HasData(
            new StorageType { Id = 1, Name = "Small Garage", Category = "Garage", Capacity = 5, Price = 10000, MonthlyCosts = 1000 },
            new StorageType { Id = 2, Name = "Large Garage", Category = "Garage", Capacity = 15, Price = 30000, MonthlyCosts = 3000 },
            new StorageType { Id = 3, Name = "Medium Garage", Category = "Garage", Capacity = 10, Price = 200000, MonthlyCosts = 2000 }
        );
    }
}