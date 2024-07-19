using BookStore.Attribute;
using BookStore.DTO;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        //all orders
        [HttpGet]
        [Sencitve]
        public IActionResult Get()
        {
            return Ok(_orderService.AllOrders());
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderDTO orderDTO)
        {
            var res = _orderService.order(DTOconverter(orderDTO));
            return Ok(res);
        }



        private Order DTOconverter(OrderDTO dto)
        {
            Order order = new Order();
            order.CstomerName = dto.CstomerName;
            foreach(var item in dto.Books)
            {
                Book book = new Book();
                book.Title = item.Title;
                order.Books.Add(book);
            }
         

            return order;
        }
    }
}
