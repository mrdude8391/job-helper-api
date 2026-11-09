using job_helper_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace job_helper_api.Data.Configurations;

public class CompaniesConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        entity.Property(c => c.Name)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(c => c.Website)
            .HasMaxLength(500);
    }
}