using LoanCalculator.Application.Abstractions;
using LoanCalculator.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoanCalculator.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services.AddSingleton<ILoanCalculatorService, LoanCalculatorService>();
}