using LoanCalculator.Application.Models;

namespace LoanCalculator.Application.Abstractions;

public interface ILoanCalculatorService
{
    public CalculateLoanPaymentsResponse CalculateLoanPayments(CalculateMonthlyLoanPaymentsRequest request);
    public CalculateLoanPaymentsResponse CalculateLoanPayments(CalculateDailyLoanPaymentsRequest request);
}