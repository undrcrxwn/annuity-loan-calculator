namespace LoanCalculator.Domain.Entities.PaymentIntervals;

public class DailyPaymentInterval(int step) : PaymentInterval
{
    public override IEnumerable<DateOnly> GetPaymentDatesBetween(DateOnly since, DateOnly until)
    {
        var date = since.AddDays(step);
        while (date <= until)
        {
            yield return date;
            date = date.AddDays(step);
        }
    }
}