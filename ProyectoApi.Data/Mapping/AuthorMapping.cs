using ProyectoApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoApi.Data.Mapping
{
    public class AuthorMapping : EntityTypeConfiguration<Author>
    {
        public AuthorMapping()
        {
            ToTable("Author").HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(b => b.FirstName).IsRequired().HasMaxLength(100);
            Property(b => b.LastName).IsRequired().HasMaxLength(100);
        }
    }
}
