namespace KPMG.XmlGenerator.Web.Validators.CgMetaAreaCreateDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaAreaValidator fluentvalidation class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{CgMetaAreaCreateDTO}" />
    public class CgMetaAreaCreateValidator : AbstractValidator<CgMetaAreaCreateDTO>
    {
        public CgMetaAreaCreateValidator()
        {
            RuleSet("CreateNewArea", () =>
            {
                RuleFor(x => x.Area.VersionId)
                .NotEmpty().WithMessage("VersionId is mandatory.");

                RuleFor(x => x.Area.AreaName)
                .NotEmpty().WithMessage("AreaName is mandatory.")
                .MaximumLength(70).WithMessage("AreaName length is not correct.");
            });
        }
    }
}
