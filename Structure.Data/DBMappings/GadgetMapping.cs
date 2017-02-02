using Structure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Data.DBMappings
{
    public class GadgetMapping : EntityTypeConfiguration<Gadget>
    {
        public GadgetMapping()
        {
            ToTable("Gadgets");

            Property(g => g.Name).HasMaxLength(50).IsRequired();
            Property(g => g.Price).HasPrecision(8, 2).IsRequired();
            Property(g => g.GadgetID).IsRequired();

        }
    }
}
