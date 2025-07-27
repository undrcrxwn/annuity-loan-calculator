using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Domain.Entities;

/// <summary>
/// Платёж по займу
/// </summary>
public class LoanPayment
{
    [DisplayFormat(DataFormatString = "{0:D}")]
    public DateOnly Date { get; set; }

    /// <summary>Размер платежа по телу</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal PrincipalPaymentAmount { get; set; }

    /// <summary>Размер платежа по процентам</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal InterestPaymentAmount { get; set; }

    /// <summary>Суммарный размер платежа</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal TotalPaymentAmount => PrincipalPaymentAmount + InterestPaymentAmount;

    /// <summary>Остаток долга</summary>
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal OutstandingPrincipalPaymentAmount { get; set; }
}