using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.IRepositories;
using Structure.IRepositories.IUnitOfWork;
using Structure.Model;
using Structure.Services.IServices;

namespace Structure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            var categories = _categoryRepository.GetAll();
            return categories;
        }

        public Category GetCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var catergory = _categoryRepository.GetCategoryByName(name);
            return catergory;
        }

        public void Remove(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }

        public bool Exixts(int id)
        {
            var result = _categoryRepository.GetById(id);
            return result == null;
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void SaveCategory()
        {
            _unitOfWork.Commit();
        }
    }
}
