using ImageUploadTest.Models.ImageImplementation;
using ImageUploadTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadTest.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Image> Images { get; set; }
  
        public DbSet<Laptop> Laptops { get; set; }



    }
}
