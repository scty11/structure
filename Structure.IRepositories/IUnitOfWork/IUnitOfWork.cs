using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.IRepositories.IUnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
