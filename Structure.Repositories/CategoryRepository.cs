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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Category GetCategoryByName(string categoryName)
        {
            try
            {
                var result = DbContext.Categories.FirstOrDefault(c => c.Name == categoryName);

                return result;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error getting categoryByName :" + ex.StackTrace);
            }
        }
    }
}
