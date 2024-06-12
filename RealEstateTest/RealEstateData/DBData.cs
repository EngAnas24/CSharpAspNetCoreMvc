using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core;
using System.ComponentModel.DataAnnotations;
namespace RealEstateData
{
    public class DBData:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SPO32LR\\SQLEXPRESS; Database=RealEstateDb; Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /* modelBuilder.Ignore<propertytype>();
             modelBuilder.Ignore<propertystatus>();
             modelBuilder.Ignore<furnishedstatus>();
             modelBuilder.Ignore<Bedrooms>();
             modelBuilder.Ignore<Bathrooms>();
             modelBuilder.Ignore<Balconys>();
             modelBuilder.Ignore<offertype>();*/

            /*modelBuilder.Entity<RealEstateProperty>()
     .HasOne(rp => rp.SavedProp) // RealEstateProperty has one SavedProp
     .WithOne(sp => sp.RealEstateProperties) // SavedProp has one RealEstateProperty
     .HasForeignKey<SavedProp>(sp => sp.RealEstatePropertiesId);*/

       

        }

        public DbSet<offertype> offertype { get; set; }
        public DbSet<propertytype> propertytype { get; set; }
        public DbSet<propertystatus> propertystatus { get; set; }
        public DbSet<furnishedstatus> furnishedstatus { get; set; }
        public DbSet<Bedrooms> Bedrooms { get; set; }
        public DbSet<Bathrooms> Bathrooms { get; set; }
        public DbSet<Balconys> Balconys { get; set; }
        public DbSet<RealEstateProperty> RealEstateProperty { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<SavedProp> savedProps { get; set; }




    }
}
