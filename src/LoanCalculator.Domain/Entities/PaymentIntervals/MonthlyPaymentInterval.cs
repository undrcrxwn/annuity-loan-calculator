namespace LoanCalculator.Domain.Entities.PaymentIntervals;

public class MonthlyPaymentInterval(int step) : PaymentInterval
{
    public override IEnumerable<DateOnly> GetPaymentDatesBetween(DateOnly since, DateOnly until)
    {
        var date = since.AddMonths(step);
        while (date <= until)
        {
            yield return date;
            date = date.AddMonths(step);
        }
    }
}