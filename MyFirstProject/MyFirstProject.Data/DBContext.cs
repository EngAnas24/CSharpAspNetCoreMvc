using Microsoft.EntityFrameworkCore;
using MyFirstProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Data
{
    public class DBContext:DbContext
    {
        public DBContext()
        {



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FO788HU;Database=DatabaseTest;Trusted_Connection=True");
        }
        public DbSet<User> Users { get; set; }


    }
}
