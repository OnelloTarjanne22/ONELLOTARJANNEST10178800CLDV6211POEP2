using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;
using System.Diagnostics;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add IHttpContextAccessor


        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserLogged()
        {
            return View();
        }
        public IActionResult PastOrders()
        {
            // Retrieve user ID from session
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            ViewData["UserID"] = userID;

            // Retrieve transactions for the user
            List<transactionTbl> transactions = transactionTbl.GetTransactionsByUserId(userID ?? 0);

            // Pass transactions to the view
            return View(transactions);
        }
        public IActionResult InsertFail()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult MyWork()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ProView()
        {
            List<productTbl> products = productTbl.GetAllProducts();
            // HttpContext.Session.SetInt32("UserID", userID);
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            ViewData["Products"] = products;
            ViewData["UserID"] = userID;

            return View();
        }
       
        public IActionResult Login()    
        {
            return View();
        }
        public IActionResult Sign()
        {
            return View();
        }
        public IActionResult Product() 
        {
            return View();
        }
        public IActionResult LoginFailed()
        {
            return View();
        }
       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
