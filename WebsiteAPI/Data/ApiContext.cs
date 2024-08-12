using Microsoft.EntityFrameworkCore;
using WebsiteAPI.models;

namespace WebsiteAPI.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<login> Login { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) :base(options)
        { 
        
        }

    }
}
