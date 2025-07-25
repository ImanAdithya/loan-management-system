using LoanSystem.Domain;
using LoanSystem.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LoanSystemWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using LoanSystem.Service;


namespace LoanSystemWebUI.Controllers
{
    public class LoanController : Controller
    {

        private readonly LoanService _loanService;


        public LoanController(LoanService loanService)
        {
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveLoan(LoanDetails details)
        {
            if (ModelState.IsValid)
            {
                var result = await _loanService.InsertLoanApplication(details);
                if (result)
                    return RedirectToAction("Index", new { success = true });
                else
                    ModelState.AddModelError("", "Failed to save loan application.");
            }

            return View("Index", details);
        }

    }
}
