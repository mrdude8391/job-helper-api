using JobHelper.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobHelper.Api.Data.Configurations;

public class CompaniesConfiguration : IEntityTypeConfiguration<Company>
