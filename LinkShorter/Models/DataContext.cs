using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.EntityFrameworkCore;
using System.IO;

namespace LinkShorter.Models {
    public class DataContext: DbContext{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            optionsBuilder.UseMySQL(config["DbConnection"]);
        }
        public DbSet<ShortLink> Links { get; set; }
    }
}
