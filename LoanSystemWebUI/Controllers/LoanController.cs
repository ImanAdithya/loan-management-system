using LoanSystem.Domain;
using LoanSystem.Service;
using Microsoft.AspNetCore.Mvc;
using LoanSystemWebUI.Models;
using System;
using System.Threading.Tasks;

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
            try
            {
                var loanTypes = await _loanService.GetLoanTypes();
                ViewBag.LoanTypes = loanTypes;

                var allLoans = await _loanService.GetAllLoanDetails();
                ViewBag.AllLoans = allLoans;

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Index Error]: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while loading the loan data.";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveLoan(LoanDetails details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _loanService.InsertLoanApplication(details);
                    TempData["SuccessMessage"] = "Loan saved successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Validation failed.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
            }

            ViewBag.LoanTypes = await _loanService.GetLoanTypes();
            ViewBag.AllLoans = await _loanService.GetAllLoanDetails();
            return View("Index", details);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            try
            {
                
                var success = await _loanService.UpdateLoanStatus(id, status);

                TempData["SuccessMessage"] = $"Loan status updated to '{status}'.";
                var allLoans = await _loanService.GetAllLoanDetails();
                ViewBag.AllLoans = allLoans;


            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error: " + ex.Message;
            }

            return RedirectToAction("Index");
        }


    }
}
