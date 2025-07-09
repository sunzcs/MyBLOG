using Microsoft.EntityFrameworkCore;
using myblog.Models; // Model klasörünüzün namespace'i

namespace myblog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Örnek DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SLang> SLang { get; set; }
        public DbSet<Lang> Lang { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Text> Text { get; set; }

    }
}