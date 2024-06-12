using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArticles.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticles.Data.Configrations
{
    public class FluientApiTest: IEntityTypeConfiguration<Author>
    {
     public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .Property(m => m.Id)
                .IsRequired();
            builder
                .Property(m => m.Facbook);
                
        }
    }
}
