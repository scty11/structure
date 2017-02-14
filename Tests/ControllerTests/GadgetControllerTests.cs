using AutoMapper;
using Moq;
using MyTested.WebApi;
using MyTested.WebApi.Builders.Contracts.Controllers;
using NUnit.Framework;
using Structure.Model;
using Structure.Services.IServices;
using Structure.Web.Controllers;
using Structure.Web.ViewModels;

namespace Tests.ControllerTests
{
    [TestFixture()]
    public class GadgetControllerTests
    {
        private Mock<IGadgetService> _fakeGadgetService;
        private Mock<IMapper> _fakeMapper;
        private IAndControllerBuilder<GadgetsController> _sutController;

        [SetUp]
        public void SetUp()
        {
            _fakeGadgetService = new Mock<IGadgetService>();
            _fakeMapper = new Mock<IMapper>();
            _sutController = GetFakeController();
        }

        [Test]
        public void PutShouldReturnBadRequest()
        {
            var obj = new GadgetViewModel()
            {
                Name = "Valid Name",
                Description = "Valid description",
                Price = 1,
                Image = "Valid Image"
            };

            _sutController
                .Calling(c => c.PutGadget(1, obj))
                .ShouldReturn()
                .BadRequest();

        }

        [Test]
        public void PutShouldReturnNotFound()
        {
            var obj = new GadgetViewModel()
            {
                GadgetID = 1,
                Name = "Valid Name",
                Description = "Valid description",
                Price = 1,
                Image = "Valid Image"
            };

            _fakeGadgetService.Setup(m => m.Exixts(It.IsAny<int>())).Returns(false);

            _sutController
                .Calling(c => c.PutGadget(1, obj))
                .ShouldReturn()
                .NotFound();

            _fakeGadgetService.Reset();
        }

        [Test]
        public void PostShouldReturnBadRequest()
        {
            var obj = new GadgetViewModel()
            {
                Name = "Valid Name",
                Price = 1,
                Image = "Valid Image"
            };

            _sutController
           .Calling(c => c.PostOrder(obj))
           .ShouldReturn()
           .BadRequest()
           .WithModelStateFor<GadgetViewModel>()
           .ContainingModelStateErrorFor(m => m.Description)
           .Containing("required");
        }

        [Test]
        public void PostShouldReturnCreated()
        {
            var obj = new GadgetViewModel()
            {
                Name = "Valid Name",
                Description = "Valid description",
                Price = 1,
                Image = "Valid Image"
            };

            var domObj = new Gadget()
            {
                GadgetID = 1,
                Name = "Valid Name",
                Description = "Valid description",
                Price = 1,
                Image = "Valid Image"
            };

            _fakeMapper.Setup(m => m.Map<GadgetViewModel, Gadget>(It.IsAny<GadgetViewModel>()))
                .Returns(domObj);

            _sutController
                .Calling(c => c.PostOrder(obj))               
                .ShouldReturn()
                .Created();

            _fakeGadgetService.Reset();
        }

        [Test]
        public void DeleteShouldReturnNotFound()
        {

            _sutController
                .Calling(c => c.DeleteOrder(1))
                .ShouldReturn()
                .NotFound();
        }

        [Test]
        public void DeleteShouldReturnOk()
        {
            _fakeGadgetService.Setup(m => m.GetGadget(It.IsAny<int>())).Returns(new Gadget());

            _sutController
                .Calling(c => c.DeleteOrder(1))
                .ShouldReturn()
                .Ok();

            _fakeGadgetService.Verify(m => m.Remove(It.IsAny<Gadget>()),Times.AtLeastOnce);
            _fakeGadgetService.Verify(m => m.SaveGadget(), Times.AtLeastOnce);
            _fakeGadgetService.Reset();
        }

        private IAndControllerBuilder<GadgetsController> GetFakeController()
        {
            return MyWebApi
                .Controller<GadgetsController>()
                .WithResolvedDependencyFor<IGadgetService>(_fakeGadgetService.Object)
                .AndAlso()
                .WithResolvedDependencyFor<IMapper>(_fakeMapper.Object);
        }
    }
}
