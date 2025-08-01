using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoanCalculator.Web.Models;

namespace LoanCalculator.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("CalculateMonthlyPayments", "AnnuityLoanCalculator");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}