using JobHelper.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobHelper.Api.Data.Configurations;

public class CompaniesConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.ToTable("companies");

        entity.HasKey(c => c.Id);

        entity.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(c => c.Website)
            .HasColumnName("website")
            .HasMaxLength(300)
            .IsRequired();
    }
}