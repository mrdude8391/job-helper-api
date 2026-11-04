using Microsoft.EntityFrameworkCore;

namespace job_helper_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

}