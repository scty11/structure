using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.IRepositories;
using Structure.IRepositories.IDbFactory;
using Structure.Model;

namespace Structure.Repositories
{
    public class GadgetOrderRepository : BaseRepository<GadgetOrder>, IGadetOrderRepository
    {
        public GadgetOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
