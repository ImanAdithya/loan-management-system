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

        public async Task<IActionResult> Index()
        {
            var loanTypes = await _loanService.GetLoanTypes();
            ViewBag.LoanTypes = loanTypes;

            var allLoans = await _loanService.GetAllLoanDetails();
            ViewBag.AllLoans = allLoans;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveLoan(LoanDetails details)
        {
            if (ModelState.IsValid)
            {
                var result = await _loanService.InsertLoanApplication(details);
                if (result)
                {
                   
                    var loanTypes = await _loanService.GetLoanTypes();
                    var allLoans = await _loanService.GetAllLoanDetails();
                    ViewBag.LoanTypes = loanTypes;
                    ViewBag.AllLoans = allLoans;

                    TempData["SuccessMessage"] = "Loan saved successfully!";
                    return View("Index"); 
                }
                else
                {
                    ModelState.AddModelError("", "Failed to save loan application.");
                }
            }

            ViewBag.LoanTypes = await _loanService.GetLoanTypes();
            ViewBag.AllLoans = await _loanService.GetAllLoanDetails();
            return View("Index", details);
        }



    }

}
