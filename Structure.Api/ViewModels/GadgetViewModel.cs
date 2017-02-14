using System.ComponentModel.DataAnnotations;

namespace Structure.Web.ViewModels
{
    public class GadgetViewModel
    {
        
        public int GadgetID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
    }
}