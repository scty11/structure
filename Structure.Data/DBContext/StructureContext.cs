using Structure.Data.DBMappings;
using Structure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Data.DBContext
{
    public class StructureContext : DbContext
    {
        public StructureContext() : base("StoreEntities")
        { }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GadgetOrder> GadgetOrders { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
        }
    }
}
  

