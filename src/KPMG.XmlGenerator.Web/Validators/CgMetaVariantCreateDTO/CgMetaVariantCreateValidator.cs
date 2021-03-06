namespace KPMG.XmlGenerator.Web.Validators.CgMetaVariantCreateDTO
{
    using FluentValidation;

    using KPMG.XmlGenerator.Core.DTOs;

    /// <summary>
    /// CgMetaVariantCreateValidator class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{KPMG.XmlGenerator.Core.DTOs.CgMetaVariantCreateDTO}" />
    public class CgMetaVariantCreateValidator : AbstractValidator<CgMetaVariantCreateDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CgMetaVariantCreateValidator"/> class.
        /// </summary>
        public CgMetaVariantCreateValidator()
        {
            RuleSet("CreateNewVariant", () =>
            {
                RuleFor(x => x.Variant.VersionId)
                .NotEmpty().WithMessage("VersionId is mandatory.");

                RuleFor(x => x.Variant.VariantName)
                .NotEmpty().WithMessage("VariantName is mandatory.")
                .MaximumLength(70).WithMessage("VariantName length is not correct.");
            });
        }
    }
}
