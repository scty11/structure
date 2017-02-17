using System.Collections.Generic;
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
    public class CategoriesControllerTests
    {
        private Mock<ICategoryService> _fakeCategoryService;
        private Mock<IMapper> _fakeMapper;
        private IAndControllerBuilder<CategoriesController> _sutController;

        [SetUp]
        public void SetUp()
        {
            _fakeCategoryService = new Mock<ICategoryService>();
            _fakeMapper = new Mock<IMapper>();
            _sutController = GetFakeController();
        }

        [Test]
        public void GetShouldReturnOk()
        {
            var vObj = new CategoryViewModel()
            {
                Name = "Valid Name"
            };
            var dObj = new Category()
            {
                Name = "Valid Name"
            };

            _fakeCategoryService.Setup(m => m.GetCategories(It.IsAny<string>())).Returns(new List<Category>() {dObj});

            _fakeMapper.Setup(m => m.Map<Category, CategoryViewModel>(It.IsAny<Category>()))
               .Returns(vObj);

            var result =  _sutController
                .Calling(c => c.GetCategories())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CategoryViewModel>>()
                .AndProvideTheModel();

            Assert.That(result, Is.Not.Empty);

        }

        [Test]
        public void GetByIdShouldReturnNotFound()
        {
            var vObj = new CategoryViewModel()
            {
                Name = "Valid Name"
            };
            var dObj = new Category()
            {
                Name = "Valid Name"
            };

            _fakeCategoryService.Setup(m => m.GetCategory(It.IsAny<int>())).Returns(dObj);

            _fakeMapper.Setup(m => m.Map<Category, CategoryViewModel>(It.IsAny<Category>()))
               .Returns(vObj);

            var result = _sutController
                .Calling(c => c.GetCategory(1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<CategoryViewModel>()
                .AndProvideTheModel();

            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public void PostShouldReturnCreated()
        {
            var vObj = new CategoryViewModel()
            {
                Name = "Valid Name"
            };
            var dObj = new Category()
            {
                Name = "Valid Name"
            };

            _fakeMapper.Setup(m => m.Map<CategoryViewModel,Category >(It.IsAny<CategoryViewModel>()))
               .Returns(dObj);

            _fakeCategoryService.Setup(m => m.CreateCategory(dObj));

            _sutController
                .Calling(c => c.PostCategory(vObj))
                .ShouldReturn()
                .Created();

        }

        [Test]
        public void PostShouldReturnBadRequest()
        {
            _sutController
                .Calling(c => c.PostCategory(new CategoryViewModel()))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<CategoryViewModel>()
                .ContainingModelStateErrorFor(m => m.Name);
        }

        private IAndControllerBuilder<CategoriesController> GetFakeController()
        {
            return MyWebApi
                .Controller<CategoriesController>()
                .WithResolvedDependencyFor<ICategoryService>(_fakeCategoryService.Object)
                .AndAlso()
                .WithResolvedDependencyFor<IMapper>(_fakeMapper.Object);
        }
    }
}
