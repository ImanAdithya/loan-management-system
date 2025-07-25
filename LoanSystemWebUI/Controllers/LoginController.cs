using Microsoft.AspNetCore.Mvc;

namespace LoanSystemWebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }     
        
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                return RedirectToAction("Index", "Loan");
            }

            ViewBag.Error = "Invalid username or password.";
            return View("Index");

        }
    }
}
