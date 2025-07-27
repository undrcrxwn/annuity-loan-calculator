using System.ComponentModel.DataAnnotations;
using LoanCalculator.Domain.Entities;

namespace LoanCalculator.Application.Models;

public class LoanPaymentResponse
{
    [DisplayFormat(DataFormatString = "{0:D}")]
    public required DateOnly Date { get; set; }

    /// <summary>Размер платежа по телу</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal PrincipalPaymentAmount { get; set; }

    /// <summary>Размер платежа по процентам</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal InterestPaymentAmount { get; set; }

    /// <summary>Суммарный размер платежа</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal TotalPaymentAmount => PrincipalPaymentAmount + InterestPaymentAmount;

    /// <summary>Остаток долга</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal OutstandingPrincipalPaymentAmount { get; set; }

    public static LoanPaymentResponse FromEntity(LoanPayment payment) => new()
    {
        Date = payment.Date,
        PrincipalPaymentAmount = payment.PrincipalPaymentAmount,
        InterestPaymentAmount = payment.InterestPaymentAmount,
        OutstandingPrincipalPaymentAmount = payment.OutstandingPrincipalPaymentAmount
    };
}