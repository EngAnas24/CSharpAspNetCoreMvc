using Microsoft.EntityFrameworkCore;
namespace Deneme1.Models
{
    public class DBData :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer method requires the Microsoft.EntityFrameworkCore.SqlServer package
            optionsBuilder.UseSqlServer("Server=DESKTOP-SPO32LR\\SQLEXPRESS;Database=UserTest;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        // DbSet representing the collection of User entities in the database
        public DbSet<User> Users { get; set; }
    }
}
