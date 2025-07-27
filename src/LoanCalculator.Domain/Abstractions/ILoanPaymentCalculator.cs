using LoanCalculator.Domain.Entities;

namespace LoanCalculator.Domain.Abstractions;

public interface ILoanPaymentCalculator
{
    public IList<LoanPayment> CalculatePayments(Loan loan);
}