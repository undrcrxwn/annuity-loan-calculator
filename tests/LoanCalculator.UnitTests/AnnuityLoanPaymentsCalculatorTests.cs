using FluentAssertions;
using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Entities.PaymentIntervals;
using LoanCalculator.Domain.Services;

namespace LoanCalculator.UnitTests;

public class AnnuityLoanPaymentCalculatorTests
{
    [Theory(DisplayName = "Payments are calculated correctly")]
    [InlineData("2025-01-01", "2025-01-23", 1, 22, 1_000_000, 0.01, 0.12)]
    [InlineData("2025-01-01", "2030-01-01", 2, 913, 5_000_000_000, 0.01, 0.01)]
    [InlineData("2025-01-01", "2030-01-01", 2, 913, 5_000_000_000, 70, 0.05)]
    [InlineData("2025-01-01", "2030-01-01", 5, 365, 1_000_000_000_000, 200_000, 0.15)]
    [InlineData("2025-01-01", "2030-01-01", 1, 365 * 5 + 1, 1, 0.01, 0.01)]
    public void CalculatePaymentsReturnsCorrectPayments(
        string since, string until, int step, int expectedCount,
        decimal amount, decimal precision, double rate)
    {
        // Arrange
        var calculator = new AnnuityLoanPaymentCalculator();
        var loan = new Loan
        {
            Since = DateOnly.ParseExact(since, "O"),
            Until = DateOnly.ParseExact(until, "O"),
            Amount = amount,
            PaymentInterval = new DailyPaymentInterval(step),
            InterestRatePerPaymentInterval = rate
        };

        // Act
        var payments = calculator.CalculatePayments(loan);

        // Assert
        payments.Should().HaveCount(expectedCount);
        payments.Last().OutstandingPrincipalPaymentAmount.Should().BeApproximately(0, precision);
        payments.Sum(payment => payment.PrincipalPaymentAmount).Should().BeApproximately(loan.Amount, precision);
        payments.Select(payment => payment.Date).Should().BeInAscendingOrder();
        payments.Select(payment => payment.TotalPaymentAmount).Should().AllBeEquivalentTo(payments.First().TotalPaymentAmount);
        payments.Select(payment => payment.PrincipalPaymentAmount).Should().BeInAscendingOrder();
        payments.Select(payment => payment.InterestPaymentAmount).Should().BeInDescendingOrder();
        payments.Select(payment => payment.OutstandingPrincipalPaymentAmount).Should().BeInDescendingOrder();
    }
}