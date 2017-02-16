using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyTested.WebApi;
using NUnit.Framework;
using Structure.Web.Controllers;
using Structure.Web.ViewModels;

namespace Tests.RouteTests
{
    [TestFixture()]
    public class CategoriesRouteTests
    {
        [Test]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Categories")
                .WithHttpMethod(HttpMethod.Get)
                .To<CategoriesController>(c => c.GetCategories());
        }

        [Test]
        public void GetByIdShouldMapCorrectly()
        {
            MyWebApi
               .Routes()
               .ShouldMap("/api/Categories/1")
               .WithHttpMethod(HttpMethod.Get)
               .To<CategoriesController>(c => c.GetCategory(1));
        }

        [Test]
        public void PostShouldBeMappedCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Categories")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Name"":""Valid Name""}")
                .To<CategoriesController>(c => c.PostCategory(new CategoryViewModel()
                {
                    Name = "Valid Name"
                }

                    )).ToValidModelState();
        }

        [Test]
        public void PutShouldBeMappedCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Categories/1")
                .WithHttpMethod(HttpMethod.Put)
                .WithJsonContent(@"{""Name"":""Valid Name""}")
                .To<CategoriesController>(c => c.PutCategory(1, new CategoryViewModel()
                {
                    Name = "Valid Name"
                }

                ))
                .ToValidModelState();
        }

        [Test]
        public void DeleteShouldBeMappedCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Categories/1")
                .WithHttpMethod(HttpMethod.Delete)
                .To<CategoriesController>(c => c.DeleteCategory(1));
        }
    }
}
