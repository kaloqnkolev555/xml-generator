namespace KPMG.XmlGenerator.Web.Validators.CgMetaAreaToObjectDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaAreaValidator fluentvalidation class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{CgMetaAreaCreateDTO}" />
    public class CgMetaAreaToObjectValidator : AbstractValidator<CgMetaAreaToObjectDTO>
    {
        public CgMetaAreaToObjectValidator()
        {
            RuleSet("MapAreaToObject", () =>
            {
                RuleFor(x => x.AreaColumnId)
                .NotEmpty().WithMessage("Area ColumnId is mandatory.");

                RuleFor(x => x.ObjectColumnId)
                .NotNull().WithMessage("Object ColumnId(s) is mandatory.")
                .NotEmpty().WithMessage("Object ColumnId(s) is mandatory.");
            });
        }
    }
}
