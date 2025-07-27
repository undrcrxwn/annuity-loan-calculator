using LoanCalculator.Domain.Abstractions;
using LoanCalculator.Domain.Entities;

namespace LoanCalculator.Domain.Services;

public class AnnuityLoanPaymentCalculator : ILoanPaymentCalculator
{
    public IList<LoanPayment> CalculatePayments(Loan loan)
    {
        var paymentDates = loan.PaymentInterval.GetPaymentDatesBetween(loan.Since, loan.Until).ToList();
        var ratePlus1PowTerms = (decimal)Math.Pow(loan.InterestRatePerPaymentInterval + 1, paymentDates.Count);
        var annuityCoefficient = (decimal)loan.InterestRatePerPaymentInterval * ratePlus1PowTerms / (ratePlus1PowTerms - 1);
        var monthlyPaymentAmount = annuityCoefficient * loan.Amount;

        var payments = new List<LoanPayment>(paymentDates.Count);
        var outstandingPrincipalPaymentAmount = loan.Amount;
        foreach (var paymentDate in paymentDates)
        {
            var interestPaymentAmount = outstandingPrincipalPaymentAmount * (decimal)loan.InterestRatePerPaymentInterval;
            var principalPaymentAmount = monthlyPaymentAmount - interestPaymentAmount;

            outstandingPrincipalPaymentAmount -= principalPaymentAmount;

            payments.Add(new LoanPayment
            {
                Date = paymentDate,
                PrincipalPaymentAmount = principalPaymentAmount,
                InterestPaymentAmount = interestPaymentAmount,
                OutstandingPrincipalPaymentAmount = outstandingPrincipalPaymentAmount
            });
        }

        return payments;
    }
}