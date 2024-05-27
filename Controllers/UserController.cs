using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class UserController : Controller
    {
        private readonly usersTbl usrtbl = new usersTbl();

        [HttpPost]
        public IActionResult Sign(usersTbl Users)
        {
            if (ModelState.IsValid)
            {
                // Checks to see if already exists
                bool userExists = usersTbl.UserExists(Users.Name, Users.Email);
                if (userExists)
                {
                    // Redirects user to the error Page to the view if user exists
                    return RedirectToAction("UserLogged", "Home");
                }
                else
                {
                    // Insert user if user does not exist
                    var result = usrtbl.insert_User(Users);
                    if (result > 0)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while signing up.");
                    }
                }
            }
            return View(Users);
        }

        [HttpGet]
        public IActionResult Sign()
        {
            return View(new usersTbl());
        }
    }

}

