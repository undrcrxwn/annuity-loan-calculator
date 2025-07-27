using System.ComponentModel.DataAnnotations;
using LoanCalculator.Domain.Entities;

namespace LoanCalculator.Application.Models;

public class CalculateLoanPaymentsResponse
{
    public required IEnumerable<LoanPaymentResponse> Payments { get; set; }

    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal OverpaymentAmount { get; set; }

    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal TotalPaymentAmount { get; set; }

    public static CalculateLoanPaymentsResponse FromEntities(IList<LoanPayment> payments) => new()
    {
        Payments = payments.Select(payment => LoanPaymentResponse.FromEntity(payment)),
        OverpaymentAmount = payments.Sum(payment => payment.InterestPaymentAmount),
        TotalPaymentAmount = payments.Sum(payment => payment.TotalPaymentAmount)
    };
}