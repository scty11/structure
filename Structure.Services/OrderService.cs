using System.Collections.Generic;
using Structure.IRepositories;
using Structure.IRepositories.IUnitOfWork;
using Structure.Model;
using Structure.Services.IServices;

namespace Structure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IGadetOrderRepository _gadetOrderRepository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IGadetOrderRepository gadetOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _gadetOrderRepository = gadetOrderRepository;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public bool Exixts(int id)
        {
            var order = _orderRepository.GetById(id);
            return order == null;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
            order.Gadgets.ForEach(g => _gadetOrderRepository.Add(new GadgetOrder() {OrderID = order.OrderID, GadgetID = g.GadgetID}));
   
            
        }

        public void Remove(Order order)
        {
            _orderRepository.Delete(order);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}