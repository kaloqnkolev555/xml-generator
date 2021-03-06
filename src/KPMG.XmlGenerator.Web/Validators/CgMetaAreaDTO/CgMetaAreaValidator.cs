namespace KPMG.XmlGenerator.Web.Validators.CgMetaAreaDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaAreaValidator fluentvalidation class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{CgMetaAreaCreateDTO}" />
    public class CgMetaAreaValidator : AbstractValidator<CgMetaAreaDTO>
    {
        public CgMetaAreaValidator()
        {
            RuleSet("EditArea", () =>
            {
                RuleFor(x => x.AreaName)
                .NotEmpty().WithMessage("AreaName is mandatory.")
                .MaximumLength(70).WithMessage("AreaName length is not correct.")
                .NotEqual("string").WithMessage("AreaName is mandatory.");

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
