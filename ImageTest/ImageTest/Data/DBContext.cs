using ImageTest.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace ImageTest.Data
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FO788HU;Database=ImagesTest;Trusted_Connection=True");
        }

        public DbSet<ProjectModel> Models { get; set; }
    }
}
