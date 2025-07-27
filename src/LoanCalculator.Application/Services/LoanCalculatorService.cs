using LoanCalculator.Application.Abstractions;
using LoanCalculator.Application.Models;
using LoanCalculator.Domain.Abstractions;
using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Entities.PaymentIntervals;

namespace LoanCalculator.Application.Services;

public class LoanCalculatorService(ILoanPaymentCalculator loanPaymentCalculator) : ILoanCalculatorService
{
    public CalculateLoanPaymentsResponse CalculateLoanPayments(CalculateMonthlyLoanPaymentsRequest request)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var loan = new Loan
        {
            Since = today,
            Until = today.AddMonths(request.TermInMonths),
            Amount = request.Amount,
            PaymentInterval = new MonthlyPaymentInterval(1),
            InterestRatePerPaymentInterval = request.AnnualInterestRatePercentage / 12 / 100,
        };
        
        var payments = loanPaymentCalculator.CalculatePayments(loan);
        return CalculateLoanPaymentsResponse.FromEntities(payments);
    }

    public CalculateLoanPaymentsResponse CalculateLoanPayments(CalculateDailyLoanPaymentsRequest request)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var loan = new Loan
        {
            Since = today,
            Until = today.AddDays(request.TermInDays),
            Amount = request.Amount,
            PaymentInterval = new DailyPaymentInterval(request.PaymentStepInDays),
            InterestRatePerPaymentInterval = request.DailyInterestRatePercentage / 100,
        };

        var payments = loanPaymentCalculator.CalculatePayments(loan);
        return CalculateLoanPaymentsResponse.FromEntities(payments);
    }
}