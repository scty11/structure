using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Structure.IRepositories;
using Structure.IRepositories.IDbFactory;
using Structure.IRepositories.IUnitOfWork;
using Structure.Repositories;
using Structure.Repositories.DbFactory;
using Structure.Repositories.UnitOfWork;
using Structure.Services;
using Structure.Services.IServices;
using Structure.Web.Mappings;

namespace Structure.Web.App_Start
{
    public class AutofacBootstraper
    {
        public static void SetAutofacWebAPI()
        {

            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            // Services
            builder.RegisterType<CategoryService>()
                .As<ICategoryService>()
                .InstancePerRequest();
            builder.RegisterType<GadgetService>()
                .As<IGadgetService>()
                .InstancePerRequest();
            builder.RegisterType<OrderService>()
                .As<IOrderService>()
                .InstancePerRequest();
            builder.RegisterType<GadgetOrderService>()
                .As<IGadgetOrderService>()
                .InstancePerRequest();

            //repos
            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .InstancePerRequest();
            builder.RegisterType<GadgetRepository>()
           .As<IGadgetRepository>()
           .InstancePerRequest();
            builder.RegisterType<OrderRepository>()
           .As<IOrderRepository>()
           .InstancePerRequest();
            builder.RegisterType<GadgetOrderRepository>()
           .As<IGadetOrderRepository>()
           .InstancePerRequest();

            //auto mapper
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();


            var container = builder.Build();
            // Set the WebApi dependency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }

        //public static void Run()
        //{
        //    SetAutofacContainer();
        //}

        //private static void SetAutofacContainer()
        //{
        //    var builder = new ContainerBuilder();

        //    builder.RegisterControllers(Assembly.GetExecutingAssembly());

        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        //    builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

        //    // Repositories
        //    builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
        //        .Where(t => t.Name.EndsWith("Repository"))
        //        .AsImplementedInterfaces().InstancePerRequest();


        //    // Services
        //    builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
        //       .Where(t => t.Name.EndsWith("Service"))
        //       .AsImplementedInterfaces().InstancePerRequest();

        //    //auto mapper
        //    var mapperConfiguration = AutoMapperConfiguration.Configure();
        //    var mapper = mapperConfiguration.CreateMapper();
        //    builder.RegisterInstance(mapper).As<IMapper>();


        //    IContainer container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //}
    }
}