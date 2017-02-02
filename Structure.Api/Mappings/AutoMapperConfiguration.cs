using AutoMapper;

namespace Structure.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
           
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                
            } );

        }
    }
}