using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.Model;

namespace Structure.Services.IServices
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        void Update(Order order);
        bool Exixts(int id);
        void  CreateOrder(Order order);
        void Remove(Order order);
        void SaveChanges();
    }
}
