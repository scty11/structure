using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Structure.Data.Seed;
using Structure.Web.App_Start;

namespace Structure.Api
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Init database
            System.Data.Entity.Database.SetInitializer(new SeedData());

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //set up autofac
            AutofacBootstraper.SetAutofacWebAPI();
        }
    }
}