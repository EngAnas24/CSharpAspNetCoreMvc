using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Deneme2.Models
{
    public class DBData:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SPO32LR\\SQLEXPRESS;Database=UserTest;Trusted_Connection=True;TrustServerCertificate=True");

        }
        public DbSet<User> users { get; set; }
    }
}
