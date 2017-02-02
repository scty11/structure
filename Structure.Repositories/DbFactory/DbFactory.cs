using Structure.Data.DBContext;
using Structure.IRepositories.IDbFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Repositories.DbFactory
{
    public class DbFactory : Disposable, IDbFactory
    {
        StructureContext _dbContext;

        public StructureContext Init()
        {
            return _dbContext ?? (_dbContext = new StructureContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
