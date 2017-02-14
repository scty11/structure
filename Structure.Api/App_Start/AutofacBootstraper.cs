using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Structure.IRepositories.IDbFactory;
using Structure.IRepositories.IUnitOfWork;
using Structure.Repositories;
using Structure.Repositories.DbFactory;
using Structure.Repositories.UnitOfWork;
using Structure.Services;
using Structure.Web.Mappings;

namespace Structure.Api
{
    public class AutofacBootstraper
    {
        public static void SetAutofacWebAPI()
        {

           
        }

        public static IContainer Run()
        {
           return  SetAutofacContainer();
        }

        private static IContainer SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();


            // Services
            builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            //auto mapper
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();


            IContainer container = builder.Build();

            return container;
        }
    }
}