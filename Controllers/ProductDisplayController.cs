using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
