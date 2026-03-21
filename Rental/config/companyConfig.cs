using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.models;

namespace Rental.config;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Vehicles).WithOne(v => v.Company).HasForeignKey(v => v.CompanyId).IsRequired();
    }
}