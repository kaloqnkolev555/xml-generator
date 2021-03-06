namespace KPMG.XmlGenerator.Web.Validators.CgMetaVariantToObjectDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    /// <summary>
    /// CgMetaVariantToObjectValidator fluent validation class
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{CgMetaVariantToObjectDTO}" />
    public class CgMetaVariantToObjectValidator : AbstractValidator<CgMetaVariantToObjectDTO>
    {
        public CgMetaVariantToObjectValidator()
        {
            RuleSet("MapVariantToObject", () =>
            {
                RuleFor(x => x.VariantColumnId)
                .NotEmpty().WithMessage("Variant ColumnId is mandatory.");

                RuleFor(x => x.ObjectColumnId)
                .NotNull().WithMessage("Object ColumnId(s) is mandatory.")
                .NotEmpty().WithMessage("Object ColumnId(s) is mandatory.");
            });
        }
    }
}
