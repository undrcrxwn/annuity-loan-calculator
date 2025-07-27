using LoanCalculator.Domain.Entities.PaymentIntervals;

namespace LoanCalculator.Domain.Entities;

/// <summary>
/// Аннуитетный займ
/// </summary>
public class Loan
{
    public required DateOnly Since { get; set; }
    public required DateOnly Until { get; set; }
    public decimal Amount { get; set; }
    public required PaymentInterval PaymentInterval { get; set; }
    public required double InterestRatePerPaymentInterval { get; set; }
}