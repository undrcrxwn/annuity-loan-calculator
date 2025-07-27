using LoanCalculator.Application.Abstractions;
using LoanCalculator.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LoanCalculator.Web.Controllers;

public class AnnuityLoanCalculatorController(ILoanCalculatorService loanCalculatorService) : Controller
{
    [HttpGet]
    public IActionResult CalculateMonthlyPayments()
    {
        var defaultViewModel = new CalculateMonthlyLoanPaymentsRequest
        {
            Amount = 10000,
            TermInMonths = 12,
            AnnualInterestRatePercentage = 12
        };

        return View(defaultViewModel);
    }

    [HttpPost]
    public IActionResult CalculateMonthlyPayments(CalculateMonthlyLoanPaymentsRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var response = loanCalculatorService.CalculateLoanPayments(request);
            return View("LoanPayments", response);
        }
        catch (OverflowException)
        {
            ModelState.AddModelError<CalculateMonthlyLoanPaymentsRequest>(model => model.TermInMonths, "Слишком большой срок займа для указанной ставки.");
            return View(request);
        }
    }

    [HttpGet]
    public IActionResult CalculateDailyPayments()
    {
        var defaultViewModel = new CalculateDailyLoanPaymentsRequest
        {
            Amount = 10000,
            TermInDays = 12,
            DailyInterestRatePercentage = 1,
            PaymentStepInDays = 1
        };

        return View(defaultViewModel);
    }

    [HttpPost]
    public IActionResult CalculateDailyPayments(CalculateDailyLoanPaymentsRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var response = loanCalculatorService.CalculateLoanPayments(request);
            return View("LoanPayments", response);
        }
        catch (OverflowException)
        {
            ModelState.AddModelError<CalculateDailyLoanPaymentsRequest>(model => model.TermInDays, "Слишком большой срок займа для указанной ставки.");
            return View(request);
        }
    }
}