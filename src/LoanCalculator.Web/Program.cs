using LoanCalculator.Application;
using LoanCalculator.Domain;
using LoanCalculator.Web.Validation;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IValidationAttributeAdapterProvider, LessThanOrEqualToAttributeAdapterProvider>();
builder.Services.AddControllersWithViews();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseRequestLocalization("ru-RU");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();