using Microsoft.EntityFrameworkCore;

namespace JobHelper.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

}