namespace KPMG.XmlGenerator.Web.Validators.CgMetaConfigurationToVariantDTO
{
    using KPMG.XmlGenerator.Core.DTOs;

    using FluentValidation;

    public class CgMetaConfigurationToVariantValidator : AbstractValidator<CgMetaConfigurationToVariantDTO>
    {
        public CgMetaConfigurationToVariantValidator()
        {
            RuleSet("MapConfigurationToVariant", () =>
            {
                RuleFor(x => x.ConfigurationColumnId)
                .NotEmpty().WithMessage("Configuration ColumnId is mandatory.");

                RuleFor(x => x.VariantColumnId)
                .NotNull().WithMessage("Variant ColumnId(s) is mandatory.")
                .NotEmpty().WithMessage("Variant ColumnId(s) is mandatory.");
            });
        }
    }
}
