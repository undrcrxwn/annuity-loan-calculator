$.validator.addMethod("less-than-or-equal-to", function (value, element, param) {
    const otherValue = $(param).val();
    return !value || !otherValue || parseFloat(value) <= parseFloat(otherValue);
}, "The value must be less than or equal to the specified field.");

$.validator.unobtrusive.adapters.add("less-than-or-equal-to", ["other"], (options) => {
    const otherPropertyName = options.params["other"];
    const otherPropertyElement = $(options.element).closest("form").find("[name='" + otherPropertyName + "']")[0];

    options.rules["less-than-or-equal-to"] = otherPropertyElement;
    if (options.message)
        options.messages["less-than-or-equal-to"] = options.message;
});