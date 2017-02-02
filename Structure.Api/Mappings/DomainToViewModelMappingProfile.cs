using AutoMapper;
using Structure.Model;
using Structure.Web.ViewModels;

namespace Structure.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {

            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();
            CreateMap<Order, OrderViewModel>();
        }
    }
}