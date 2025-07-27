using LoanCalculator.Domain.Abstractions;
using LoanCalculator.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoanCalculator.Domain;

public static class ConfigureServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services) =>
        services.AddSingleton<ILoanPaymentCalculator, AnnuityLoanPaymentCalculator>();
}