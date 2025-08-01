using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using myblog.Models; // Model klasörünüzün namespace'i

namespace myblog.Data
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Me> Me { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Lang> Lang { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Text> Text { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<Link> Links { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}