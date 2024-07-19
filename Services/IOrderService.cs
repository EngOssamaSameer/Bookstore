
using BookStore.Models;

namespace BookStore.Services
{
    public interface IOrderService
    {
        public string order(Order order);

        public List<Order> AllOrders();

       
    }
}
