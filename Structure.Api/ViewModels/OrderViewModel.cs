using System.Collections.Generic;

namespace Structure.Web.ViewModels
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public List<GadgetViewModel> Gadgets { get; set; }
    }
}