using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyArticles.Core;
using MyArticles.Data.Configrations;

namespace MyArticles.Data
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FO788HU;Database=DBArtical;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            new FluientApiTest().Configure(modelBuilder.Entity<Author>());

        }

        public DbSet<Category> Category { get; set; }
       
        public DbSet<Author> Author { get; set; }
     
        public DbSet<AuthorPost> AuthorPost { get; set; }

    }
}

      
