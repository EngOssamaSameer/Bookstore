using BookStore.Context;
using BookStore.Models;

namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _ctx;

        public OrderService(AppDbContext appDbContext)
        {
            this._ctx = appDbContext;
        }

        public List<Order> AllOrders()
        {
            return _ctx.TbOrders.ToList();
        }

        public string order(Order order)
        {
            foreach(var item in order.Books)
            {
                var bookIndatabase = _ctx.TbBooks.FirstOrDefault(e => e.Title == item.Title);
                if (bookIndatabase != null)
                {
                    if(bookIndatabase.Copies == 0)
                    {
                        return $"this book : {bookIndatabase.Title} not avalibal";
                    }
                    else
                    {
                        order.Books.Remove(item);
                        order.Books.Append(bookIndatabase);
                        continue;
                    }
                }
                return $"this book: {item.Title} not in database";
            }

            _ctx.TbOrders.Add(order);
            _ctx.SaveChanges();
            return $"Hello {order.CstomerName} Your Order is Done Successfully 🥳🥳";

        }



    }
}
