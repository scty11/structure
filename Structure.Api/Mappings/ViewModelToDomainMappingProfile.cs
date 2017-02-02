using AutoMapper;
using Structure.Model;
using Structure.Web.ViewModels;

namespace Structure.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();
            CreateMap<Order, OrderViewModel>();
        }
    }
}