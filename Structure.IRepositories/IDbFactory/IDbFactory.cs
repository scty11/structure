using Structure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.IRepositories.IDbFactory
{
    public interface IDbFactory : IDisposable
    {
        StructureContext Init();
    }
}
