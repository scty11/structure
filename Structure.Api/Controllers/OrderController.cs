using System.Net;
using System.Web.Http;
using AutoMapper;
using Structure.Model;
using Structure.Services.IServices;
using Structure.Web.ViewModels;

namespace Structure.Web.Controllers
{
    public class OrderController : System.Web.Http.ApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public IHttpActionResult GetOrders()
        {
            return Ok(_orderService.GetOrders());
        }

        public IHttpActionResult GetOrder(int id)
        {
            OrderViewModel vm = null;
            Order domain = null;

            domain = _orderService.GetOrder(id);

            if (domain == null)
            {
                return NotFound();
            }

            vm = _mapper.Map<Order, OrderViewModel>(domain);

            return Ok(vm);

        }

        public IHttpActionResult PutOrder(int id, OrderViewModel vm)
        {
            Order domain = null;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vm.OrderID)
            {
                return BadRequest();
            }
            if (_orderService.Exixts(id))
            {
                return NotFound();
            }


            domain = _mapper.Map<OrderViewModel, Order>(vm);

            _orderService.Update(domain);

            return StatusCode(HttpStatusCode.NoContent);

        }

        public IHttpActionResult PostOrder(OrderViewModel vm)
        {
            Order domain = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            domain = _mapper.Map<OrderViewModel, Order>(vm);

           _orderService.CreateOrder(domain);
           _orderService.SaveChanges();

            return CreatedAtRoute("Default", new { controller = "Home", action = "ViewOrder", id = domain.OrderID }, domain);
        }

        public IHttpActionResult DeleteOrder(int id)
        {
            Order domain = _orderService.GetOrder(id);

            if (domain == null)
            {
                return NotFound();
            }
            _orderService.Remove(domain);
            _orderService.SaveChanges();

            return Ok();
        }

        
    }
}
