using JobHelper.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobHelper.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }
    public DbSet<User> Users => Set<User>();
}