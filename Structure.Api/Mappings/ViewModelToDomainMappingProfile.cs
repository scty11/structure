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
            CreateMap<CategoryViewModel,Category>();
            CreateMap<GadgetViewModel,Gadget>();
            CreateMap<OrderViewModel,Order>();
        }
    }
}