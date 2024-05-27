using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Login(string email, string name)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
               HttpContext.Session.SetInt32("UserID", userID);
                
                return RedirectToAction("Proview", "Home", new { userID = userID });
            }
            else
            {
                return View("LoginFailed");
            }
        }
    }
}
