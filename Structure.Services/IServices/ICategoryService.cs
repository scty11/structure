using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.Model;

namespace Structure.Services.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void Remove(Category category);
        void Update(Category category);
        bool Exixts(int id);
        void CreateCategory(Category category);
        void SaveCategory();
    }
}
