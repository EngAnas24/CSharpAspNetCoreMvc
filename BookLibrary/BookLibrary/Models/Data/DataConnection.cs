using Microsoft.EntityFrameworkCore;
namespace BookLibrary.Models.Data
{
    public class DataConnection:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SPO32LR\\SQLEXPRESS;Database=BookLibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }

    }
}
