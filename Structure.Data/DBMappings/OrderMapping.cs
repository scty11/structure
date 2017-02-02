using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.Model;

namespace Structure.Data.DBMappings
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            Ignore(o => o.Gadgets);
        }
    }
}
