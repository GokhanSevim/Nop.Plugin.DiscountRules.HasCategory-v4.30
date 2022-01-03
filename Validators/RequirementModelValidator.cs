using System.Text.RegularExpressions;
using FluentValidation;
using Nop.Plugin.DiscountRules.HasCategory.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.DiscountRules.HasCategory.Validators
{
    /// <summary>
    /// Represents an <see cref="RequirementModel"/> validator.
    /// </summary>
    public class RequirementModelValidator : BaseNopValidator<RequirementModel>
    {
        public RequirementModelValidator(ILocalizationService localizationService)
        {
            RuleFor(model => model.DiscountId)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.DiscountRules.HasCategory.Fields.DiscountId.Required"));
            RuleFor(model => model.CategoryIds)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.DiscountRules.HasCategory.Fields.CategoryIds.Required"));
            RuleFor(model => model.CategoryIds)
                .Must(value => !Regex.IsMatch(value, @"(?!\d+)(?:[^ ,:-])"))
                .WithMessage(localizationService.GetResource("Plugins.DiscountRules.HasCategory.Fields.CategoryIds.InvalidFormat"))
                .When(model => !string.IsNullOrWhiteSpace(model.CategoryIds));
        }
    }
}
