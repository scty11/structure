using Structure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.IRepositories;
using Structure.IRepositories.IDbFactory;

namespace Structure.Repositories
{
    public class GadgetRepository : BaseRepository<Gadget>, IGadgetRepository
    {
        public GadgetRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
