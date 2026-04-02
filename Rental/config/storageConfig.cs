using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class StorageConfig : IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.ToTable("Storages");
        builder.HasKey(v => v.Id);
        builder.HasOne<StorageType>(g => g.StorageType).WithMany().HasForeignKey(g => g.TypeId);
    }
}