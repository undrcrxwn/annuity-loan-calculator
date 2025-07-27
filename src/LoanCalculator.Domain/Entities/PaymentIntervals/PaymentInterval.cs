namespace LoanCalculator.Domain.Entities.PaymentIntervals;

public abstract class PaymentInterval
{
    public abstract IEnumerable<DateOnly> GetPaymentDatesBetween(DateOnly since, DateOnly until);
}