using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Application.Attributes;

public class LessThanOrEqualToAttribute(string otherPropertyName) : ValidationAttribute
{
    public readonly string OtherPropertyName = otherPropertyName;

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IComparable comparableValue)
            throw new ArgumentException("The provided value is not comparable.", nameof(value), null);

        var property = validationContext.ObjectType.GetProperty(OtherPropertyName);
        if (property is null)
            throw new ArgumentException("No property with the given name found.");

        var otherValue = property.GetValue(validationContext.ObjectInstance);
        var comparisonResult = comparableValue.CompareTo(otherValue);
        return comparisonResult <= 0
            ? ValidationResult.Success!
            : new ValidationResult(ErrorMessage);
    }
}