using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Structure.Model;
using Structure.Services.IServices;
using Structure.Web.ViewModels;

namespace Structure.Web.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/Categories")]
        public IHttpActionResult GetCategories()
        {
            var results = _categoryService.GetCategories().ToList();

            var vm = results
                     .Select(category => _mapper.Map<Category, CategoryViewModel>(category))
                     .ToList();

            return Ok(vm);
        }

        [HttpGet]
        [Route("api/Categories/{id}")]
        public IHttpActionResult GetCategory(int id)
        {

            var domain = _categoryService.GetCategory(id);

            if (domain == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<Category, CategoryViewModel>(domain);

            return Ok(vm);

        }

        [HttpPut]
        [Route("api/Categories/{id}")]
        public IHttpActionResult PutCategory(int id, CategoryViewModel vm)
        {
            Category domain = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vm.CategoryID)
            {
                return BadRequest();
            }
            if (_categoryService.Exixts(id))
            {
                return NotFound();
            }


            domain = _mapper.Map<CategoryViewModel, Category>(vm);

            _categoryService.Update(domain);

            return StatusCode(HttpStatusCode.NoContent);

        }

        [HttpPost]
        [Route("api/Categories")]
        public IHttpActionResult PostCategory(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domain = _mapper.Map<CategoryViewModel, Category>(vm);

            _categoryService.CreateCategory(domain);
            _categoryService.SaveCategory();

            return CreatedAtRoute("DefaultApi", new { id = domain.CategoryID }, domain);
        }

        [HttpDelete]
        [Route("api/Categories/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category domain = _categoryService.GetCategory(id);

            if (domain == null)
            {
                return NotFound();
            }
            _categoryService.Remove(domain);
            _categoryService.SaveCategory();

            return Ok();
        }
    }
}
