namespace KPMG.XmlGenerator.Web.Validators.CgMetaVariantCreateDTO
{
    using FluentValidation;

    using KPMG.XmlGenerator.Core.DTOs;

    public class CgMetaVariantValidator : AbstractValidator<CgMetaVariantDTO>
    {
        public CgMetaVariantValidator()
        {
            RuleSet("EditVariant", () =>
            {
                RuleFor(x => x.VariantName)
                .NotEmpty().WithMessage("VariantName is mandatory.")
                .MaximumLength(70).WithMessage("Please fill in maximum 70 symbols.");

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
