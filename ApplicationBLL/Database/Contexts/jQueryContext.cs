using ApplicationBLL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationBLL.Database.Contexts
{
    public class jQueryContext : ApplicationContext
    {
        public DbSet<jQueryModel> Table => Set<jQueryModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Database");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            optionsBuilder.UseSqlite($"Data Source={path}\\jquery.db");
        }
    }
}
