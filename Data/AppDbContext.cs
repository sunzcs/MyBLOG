using Microsoft.EntityFrameworkCore;
using myblog.Models; // Model klasörünüzün namespace'i

namespace myblog.Data
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Me> Me { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<SLang> SLang { get; set; }
        public DbSet<Lang> Lang { get; set; }
        public DbSet<Skills> Skills { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}