using ProyectoApi.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoApi.Data.Mapping
{
    public class BookMapping : EntityTypeConfiguration<Book>
    {
        public BookMapping()
        {
            ToTable("Book").HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(b => b.Description).IsOptional().HasMaxLength(200);
            Property(b => b.Title).IsRequired();
        }
    }
}
