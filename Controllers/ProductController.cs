using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class ProductController : Controller
    {
        private readonly productTbl _prodtbl = new productTbl();
        private readonly SearchService _searchService;
public ProductController(SearchService searchService)
        {
            _searchService = searchService;
        }
        public async Task<IActionResult> Search(string query)
        {
            var results = await _searchService.SearchProductsAsync(query);
            return View(results);
        }
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
