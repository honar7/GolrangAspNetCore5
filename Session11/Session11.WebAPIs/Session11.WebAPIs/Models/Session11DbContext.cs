using Microsoft.EntityFrameworkCore;

namespace Session11.WebAPIs.Models
{
    public class Session11DbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=Session11;User Id=sa;Password=1qaz!QAZ");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
