using System.Net.Http;
using MyTested.WebApi;
using NUnit.Framework;
using Structure.Web.Controllers;
using Structure.Web.ViewModels;

namespace Tests.RouteTests
{
    [TestFixture()]
    public class GadgetsRouteTests
    {
       

        [Test]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Gadgets")
                .WithHttpMethod(HttpMethod.Get)
                .To<GadgetsController>(c => c.GetGadgets());
        }

        [Test]
        public void GetByIdShouldMapCorrectly()
        {
            MyWebApi
               .Routes()
               .ShouldMap("/api/Gadgets/1")
               .WithHttpMethod(HttpMethod.Get)
               .To<GadgetsController>(c => c.GetGadget(1));
        }
        
        [Test]
        public void PostShouldBeMappedCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Gadgets")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"":""Valid Name"",""Description"":""Valid Description"",""Price"":""1"",""Image"":""Valid Image""}")
                .To<GadgetsController>(c => c.PostOrder( new GadgetViewModel()
                    {
                        Name = "Valid Name",
                        Description = "Valid Description",
                        Price = 1,
                        Image = "Valid Image"
                }
                    
                    )).ToValidModelState();
        }

        [Test]
        public void PutShouldBeMappedCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Gadgets/1")
                .WithHttpMethod(HttpMethod.Put)
                .WithJsonContent(@"{""Name"":""Valid Name"",""Description"":""Valid Description"",""Price"":""1"",""Image"":""Valid Image""}")
                .To<GadgetsController>(c => c.PutGadget(1,new GadgetViewModel()
                    {
                        Name = "Valid Name",
                        Description = "Valid Description",
                        Price = 1,
                        Image = "Valid Image"
                    }

                ))
                .ToValidModelState();
        }

        [Test]
        public void DeleteShouldBeMappedCorrectly()
         {
             MyWebApi
                 .Routes()
                 .ShouldMap("/api/Gadgets/1")
                 .WithHttpMethod(HttpMethod.Delete)
                 .To<GadgetsController>(c => c.DeleteOrder(1));
         }
       
    }
}
