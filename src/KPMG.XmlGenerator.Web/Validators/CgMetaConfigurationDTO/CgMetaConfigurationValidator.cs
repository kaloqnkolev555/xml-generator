namespace KPMG.XmlGenerator.Web.Validators.CgMetaConfigurationDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaConfigurationValidator class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{KPMG.XmlGenerator.Core.DTOs.CgMetaConfigurationDTO}" />
    public class CgMetaConfigurationValidator : AbstractValidator<CgMetaConfigurationDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaConfigurationValidator"/> class.
        /// </summary>
        public CgMetaConfigurationValidator()
        {
            RuleSet("EditConfiguration", () =>
            {
                RuleFor(x => x.ConfigurationName)
                .NotEmpty().WithMessage("ConfigurationName is mandatory.")
                .MaximumLength(70).WithMessage("ConfigurationName length is not correct.");

                RuleFor(x => x.VersionId)
                .NotEmpty()
                .WithMessage("VersionId is mandatory.");

                RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is not valid.");
            });
        }
    }
}
