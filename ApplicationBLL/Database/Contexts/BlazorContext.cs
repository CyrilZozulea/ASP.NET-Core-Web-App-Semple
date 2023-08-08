using ApplicationBLL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationBLL.Database.Contexts
{
    public class BlazorContext : ApplicationContext
    {
        public DbSet<BlazorModel> Table => Set<BlazorModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Database");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            optionsBuilder.UseSqlite($"Data Source={path}\\blazor.db");
        }
    }
}
