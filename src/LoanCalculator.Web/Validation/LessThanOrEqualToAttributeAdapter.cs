using LoanCalculator.Application.Attributes;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace LoanCalculator.Web.Validation;

public class LessThanOrEqualToAttributeAdapter(LessThanOrEqualToAttribute attribute, IStringLocalizer stringLocalizer)
    : AttributeAdapterBase<LessThanOrEqualToAttribute>(attribute, stringLocalizer)
{
    public override void AddValidation(ClientModelValidationContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-less-than-or-equal-to", GetErrorMessage(context));
        MergeAttribute(context.Attributes, "data-val-less-than-or-equal-to-other", Attribute.OtherPropertyName);
    }

    public override string GetErrorMessage(ModelValidationContextBase validationContext) =>
        GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
}