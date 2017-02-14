using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyTested.WebApi;
using NUnit.Framework;
using Structure.Api;

namespace Structure.Tests.ControllerTests
{
    [TestFixture]
    public class GadgetsTests
    {
        [Test]
        public void Test()
        {
            var server = MyWebApi.Server().Starts<Startup>(host: "http://localhost", port: 9876);

            server
               .WithHttpRequestMessage(
        request => request
            .WithMethod(HttpMethod.Get)
            .WithRequestUri("/api/Default"))
    .ShouldReturnHttpResponseMessage()
    .WithStatusCode(HttpStatusCode.OK);

            MyWebApi.Server().Stops();
        }
    }
}
