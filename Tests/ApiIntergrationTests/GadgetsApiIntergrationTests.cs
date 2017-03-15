using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using MyTested.WebApi;
using Newtonsoft.Json;
using NUnit.Framework;
using Structure.Api;
using Structure.Model;
using Structure.Web.ViewModels;

namespace Tests.ApiIntergrationTests
{
    [TestFixture()]
    public class GadgetsApiIntergrationTests
    {
        private int createdId;

        [SetUp]
        public void SetUp()
        {
            MyWebApi.Server().Starts<Startup>(host: "https://localhost", port: 50394);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            MyWebApi.Server().Stops();
        }

        [Test,Order(1)]
        public void GetAllGadgets()
        {
           var result =   MyWebApi
                .Server()
                .Working()
                .WithHttpRequestMessage(
                    request => request
                        .WithMethod(HttpMethod.Get)
                        .WithRequestUri("/api/Gadgets"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK)
                .WithResponseModelOfType<List<GadgetViewModel>>()
                .AndProvideTheModel();

            Assert.Greater(result.Count, 0);

        }

        [Test, Order(2)]
        public void CreateGadget()
        {
            var domObj = new Gadget()
            {
                Name = "Valid Name",
                Description = "Valid description",
                Price = 1,
                Image = "Valid Image",
                CategoryID = 1
            };

          var response =   MyWebApi
                .Server()
                .Working()
                .WithHttpRequestMessage(
                    request => request
                        .WithMethod(HttpMethod.Post)
                        .WithRequestUri("/api/Gadgets")
                        .WithJsonContent(JsonConvert.SerializeObject(domObj)))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK)
                .WithResponseModelOfType<GadgetViewModel>()
                .AndProvideTheModel();

            Assert.That(response.GadgetID, Is.GreaterThan(0));

            createdId = response.GadgetID;
        }

        [Test, Order(3)]
        public void DeleteGadgetShouldReturnOk()
        {

            MyWebApi
                .Server()
                .Working()
                .WithHttpRequestMessage(
                    request => request
                        .WithMethod(HttpMethod.Delete)
                        .WithRequestUri("/api/Gadgets/" + createdId))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK);

           
        }
    }
}
