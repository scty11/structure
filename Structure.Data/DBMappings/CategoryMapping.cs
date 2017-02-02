using Structure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Data.DBMappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Categories");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
