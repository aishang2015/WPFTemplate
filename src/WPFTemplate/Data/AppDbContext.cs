using Microsoft.EntityFrameworkCore;

namespace WPFTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
