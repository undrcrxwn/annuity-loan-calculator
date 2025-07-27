using FluentAssertions;
using LoanCalculator.Domain.Entities.PaymentIntervals;

namespace LoanCalculator.UnitTests;

public class LoanPaymentIntervalTests
{
    [Theory(DisplayName = "Monthly payment interval returns correct dates")]
    [InlineData("2029-01-01", "2030-12-23", 1, 12 * 2 - 1)]
    [InlineData("2025-01-01", "2030-12-23", 1, 12 * 6 - 1)]
    [InlineData("2025-01-01", "2030-12-23", 2, 12 * 3 - 1)]
    [InlineData("2025-01-01", "2030-01-01", 12, 5)]
    [InlineData("2025-01-01", "2025-12-23", 1, 11)]
    [InlineData("2025-01-01", "2025-02-23", 1, 1)]
    [InlineData("2025-01-01", "2025-01-23", 1, 0)]
    public void MonthlyPaymentIntervalReturnsCorrectDates(string since, string until, int step, int expectedCount)
    {
        // Arrange
        var interval = new MonthlyPaymentInterval(step);
        var sinceDate = DateOnly.ParseExact(since, "O");
        var untilDate = DateOnly.ParseExact(until, "O");

        // Act
        var dates = interval.GetPaymentDatesBetween(sinceDate, untilDate).ToList();

        // Assert
        dates.Should().HaveCount(expectedCount);
        dates.Should().BeInAscendingOrder();
    }

    [Theory(DisplayName = "Daily payment interval returns correct dates")]
    [InlineData("2025-01-01", "2025-01-23", 1, 22)]
    [InlineData("2025-01-01", "2025-01-22", 2, 10)]
    [InlineData("2025-12-29", "2026-01-02", 1, 4)]
    [InlineData("2025-12-29", "2026-01-02", 2, 2)]
    [InlineData("2025-02-28", "2025-03-02", 1, 2)]
    [InlineData("2028-02-28", "2028-03-02", 1, 3)]
    [InlineData("2025-01-01", "2025-12-31", 1, 364)]
    [InlineData("2028-01-01", "2028-12-31", 365, 1)]
    [InlineData("2028-01-01", "2028-12-31", 365 / 5, 5)]
    [InlineData("2025-01-01", "2025-12-31", 364, 1)]
    [InlineData("2025-01-01", "2025-12-31", 364 / 4, 4)]
    public void DailyPaymentIntervalReturnsCorrectDates(string since, string until, int step, int expectedCount)
    {
        // Arrange
        var interval = new DailyPaymentInterval(step);
        var sinceDate = DateOnly.ParseExact(since, "O");
        var untilDate = DateOnly.ParseExact(until, "O");

        // Act
        var dates = interval.GetPaymentDatesBetween(sinceDate, untilDate).ToList();

        // Assert
        dates.Should().HaveCount(expectedCount);
        dates.Should().BeInAscendingOrder();
    }
}