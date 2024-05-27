using Microsoft.AspNetCore.Mvc;
using ONELLOTARJANNEST10178800CLDV6211POEPART1.Models;
using System.Collections.Generic;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID, string productName, string price)
        {
            try
            {
                int rowsAffected = transactionTbl.InsertTransaction(userID, productID, productName, price);
                if (rowsAffected > 0)
                {
                    return RedirectToAction("ProView", "Home");
                }
                else
                {
                    return View("OrderFailed");
                }
            }
            catch
            {
                // Log the exception details
                return View("OrderFailed");
            }
        }
        [HttpGet]
        public ActionResult ViewUserTransactions()
        {
            try
            {
                int? userID = HttpContext.Session.GetInt32("UserID");

                if (userID == null || userID <= 0)
                {
                    // Handle invalid userID or user not logged in
                    return View("Error");
                }

                // Log the retrieved userID
                Console.WriteLine($"Retrieved userID from session: {userID}");

                List<transactionTbl> transactions = transactionTbl.GetTransactionsByUserId(userID.Value);

                if (transactions == null || transactions.Count == 0)
                {
                    // Handle case where no transactions are found
                    return View("OrderFailed");
                }
                return View("PastOrders", transactions);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error: {ex.Message}");
                return View("Error");
            }
        }

    }
}
