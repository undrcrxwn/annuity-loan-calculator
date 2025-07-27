using System.ComponentModel.DataAnnotations;
using LoanCalculator.Application.Attributes;

namespace LoanCalculator.Application.Models;

public class CalculateDailyLoanPaymentsRequest
{
    [Display(Name = "Сумма займа")]
    [Required(ErrorMessage = "Укажите сумму займа.")]
    [Range(typeof(decimal), "0,01", "1000000000000", ErrorMessage = "Сумма займа должна лежать в диапазоне от 0,01 руб. до 1 трлн. руб.")]
    public required decimal Amount { get; set; }

    [Display(Name = "Срок займа")]
    [Required(ErrorMessage = "Укажите срок займа.")]
    [Range(1, 1000 * 365, ErrorMessage = "Срок займа должен лежать в диапазоне от 1 дня до 1 000 лет.")]
    public required int TermInDays { get; set; }

    [Display(Name = "Процентная ставка")]
    [Required(ErrorMessage = "Укажите процентную ставку.")]
    [Range(0.0001, 10_000, ErrorMessage = "Процентная ставка должна лежать в диапазоне от 0.0001 % до 10 000 %.")]
    public required double DailyInterestRatePercentage { get; set; }

    [Display(Name = "Шаг платежа")]
    [Required(ErrorMessage = "Укажите шаг платежа.")]
    [Range(1, 1000 * 365, ErrorMessage = "Шаг платежа должен лежать в диапазоне от 1 дня до 1 000 лет.")]
    [LessThanOrEqualTo(nameof(TermInDays), ErrorMessage = "Шаг платежа не должен превышать срок займа.")]
    public required int PaymentStepInDays { get; set; }
}