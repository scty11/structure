using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Structure.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }

        public List<GadgetViewModel> Gadgets { get; set; }
    }
}