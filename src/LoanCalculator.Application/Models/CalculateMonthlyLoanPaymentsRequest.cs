using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Application.Models;

public class CalculateMonthlyLoanPaymentsRequest
{
    [Display(Name = "Сумма займа"), DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Укажите сумму займа.")]
    [Range(typeof(decimal), "0,01", "1000000000000", ErrorMessage = "Сумма займа должна лежать в диапазоне от 0,01 руб. до 1 трлн. руб.")]
    public required decimal Amount { get; set; }

    [Display(Name = "Срок займа")]
    [Required(ErrorMessage = "Укажите срок займа.")]
    [Range(1, 1000 * 12, ErrorMessage = "Срок займа должен лежать в диапазоне от 1 месяца до 1 000 лет.")]
    public required int TermInMonths { get; set; }
    
    [Display(Name = "Процентная ставка")]
    [Required(ErrorMessage = "Укажите процентную ставку.")]
    [Range(0.0001, 10_000, ErrorMessage = "Процентная ставка должна лежать в диапазоне от 0.0001 % до 10 000 %.")]
    public required double AnnualInterestRatePercentage { get; set; }
}