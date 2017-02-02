using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.IRepositories.IBaseRepository;
using Structure.Model;

namespace Structure.IRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}
