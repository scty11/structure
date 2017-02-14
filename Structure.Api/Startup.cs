using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Microsoft.Owin;
using Owin;
using Structure.IRepositories;
using Structure.IRepositories.IDbFactory;
using Structure.IRepositories.IUnitOfWork;
using Structure.Repositories;
using Structure.Repositories.DbFactory;
using Structure.Repositories.UnitOfWork;
using Structure.Services;
using Structure.Services.IServices;
using Structure.Web.Mappings;

[assembly: OwinStartup(typeof(Structure.Api.Startup))]

namespace Structure.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ////Swashbuckle.Bootstrapper.Init(config);
            
            HttpConfiguration config = new HttpConfiguration();
           
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

          
            //set up autofac
          
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
            config.DependencyResolver = resolver;

            WebApiConfig.Register(config);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
