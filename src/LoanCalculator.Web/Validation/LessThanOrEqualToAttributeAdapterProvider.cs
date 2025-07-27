using System.ComponentModel.DataAnnotations;
using LoanCalculator.Application.Attributes;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace LoanCalculator.Web.Validation;

public class LessThanOrEqualToAttributeAdapterProvider : ValidationAttributeAdapterProvider, IValidationAttributeAdapterProvider
{
    IAttributeAdapter? IValidationAttributeAdapterProvider.GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer? stringLocalizer)
    {
        return attribute is LessThanOrEqualToAttribute lessThanOrEqualToAttribute
            ? new LessThanOrEqualToAttributeAdapter(lessThanOrEqualToAttribute, stringLocalizer!)
            : base.GetAttributeAdapter(attribute, stringLocalizer);
    }
}