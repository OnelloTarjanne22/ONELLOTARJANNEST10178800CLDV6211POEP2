using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            var result = await _orderService.PlaceOrderAsync(order);
            return View("OrderConfirmation", result);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }
    }

}
