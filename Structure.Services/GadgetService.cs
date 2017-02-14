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
    public class GadgetService : IGadgetService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGadgetRepository _gadgetRepository;

        public GadgetService(IGadgetRepository gadgetRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _gadgetRepository = gadgetRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }


        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = _gadgetRepository.GetAll();
            return gadgets;
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var catergory = _categoryRepository.GetCategoryByName(categoryName);
            var catergoryGadets = catergory.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
            return catergoryGadets;
        }

        public Gadget GetGadget(int id)
        {
            var gadget = _gadgetRepository.GetById(id);
            return gadget;
        }

        public void Remove(Gadget gadget)
        {
           _gadgetRepository.Delete(gadget);
        }

        public void Update(Gadget gadget)
        {
            _gadgetRepository.Update(gadget);
        }

        public bool Exixts(int id)
        {
            var result = _gadgetRepository.GetById(id);
            return result != null;
        }

        public void CreateGadget(Gadget gadget)
        {
            _gadgetRepository.Add(gadget);
        }

        public void SaveGadget()
        {
            _unitOfWork.Commit();
        }
    }
}
