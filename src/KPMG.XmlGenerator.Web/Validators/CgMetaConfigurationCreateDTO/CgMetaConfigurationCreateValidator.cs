namespace KPMG.XmlGenerator.Web.Validators.CgMetaConfigurationCreateDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaConfigurationCreateValidator class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{KPMG.XmlGenerator.Core.DTOs.CgMetaConfigurationCreateDTO}" />
    public class CgMetaConfigurationCreateValidator : AbstractValidator<CgMetaConfigurationCreateDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaConfigurationCreateValidator"/> class.
        /// </summary>
        public CgMetaConfigurationCreateValidator()
        {
            RuleSet("CreateNewConfiguration", () =>
            {
                RuleFor(c => c.Configuration.VersionId)
                .NotEmpty().WithMessage("VersionId is mandatory.");

                RuleFor(c => c.Configuration.ConfigurationName)
                .NotEmpty().WithMessage("Configuration name is mandatory.")
                .MaximumLength(70).WithMessage("Please fill in maximum 70 symbols.");

                RuleFor(c => c.MapMetaVariantIdColumns)
                .NotEmpty().WithMessage("At least one variant must be selected.");
            });
        }
    }
}
