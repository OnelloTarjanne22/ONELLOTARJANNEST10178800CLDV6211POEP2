using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class ProductController : Controller
    {
        private readonly productTbl _prodtbl = new productTbl();

        [HttpPost]
        public ActionResult Product(productTbl products)
        {
            var result2 = _prodtbl.insert_product(products);
            if (result2 > 0)
            {
                // Insert successful
                return RedirectToAction("Proview", "Home");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Product()
        {
            return View();
        }
    }
}
