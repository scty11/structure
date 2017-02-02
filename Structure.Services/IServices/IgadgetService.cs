using System.Collections.Generic;
using Structure.Model;

namespace Structure.Services.IServices
{
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Gadget GetGadget(int id);
        void Remove(Gadget gadget);
        void Update(Gadget gadget);
        bool Exixts(int id);
        void CreateGadget(Gadget gadget);
        void SaveGadget();
    }
}
