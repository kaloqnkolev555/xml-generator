namespace KPMG.XmlGenerator.Web.Validators.CgMetaObjectDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaAreaValidator fluentvalidation class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{CgMetaAreaCreateDTO}" />
    public class CgMetaObjectValidator : AbstractValidator<CgMetaObjectDTO>
    {
        public CgMetaObjectValidator()
        {
            RuleSet("EditObject", () =>
            {
                RuleFor(x => x.CgMetaObjectName)
                .NotEmpty()
                .NotEqual("string")
                .WithMessage("ObjectName is mandatory.");

                RuleFor(x => x.VersionId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("VersionId connot be zero or less.");

                RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Id is not valid.");
            });

            RuleSet("CreateNewObject", () =>
            {
                RuleFor(x => x.CgMetaObjectName)
                .NotEmpty()
                .NotEqual("string")
                .WithMessage("ObjectName is mandatory.");
            });

            RuleSet("DeleteObject", () =>
            {
                RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Id is not valid.");
            });
        }
    }
}
