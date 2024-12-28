using Microsoft.EntityFrameworkCore;
using PlexManager.Models;

namespace PlexManager.Database
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }

        public SQLiteContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, $"{AppInfo.Name}.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
