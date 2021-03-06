namespace KPMG.XmlGenerator.Web.Validators.CgMetaObjectDTO
{
    using FluentValidation;
    using KPMG.XmlGenerator.Core.DTOs;

    public class CgMetaObjectNameValidationDtoValidator : AbstractValidator<CgMetaObjectNameValidationDTO>
    {
        public CgMetaObjectNameValidationDtoValidator()
        {
            RuleSet(nameof(Controllers.ObjectController.ValidateName), () =>
            {
                RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Mandatory field.");
            });
        }
    }
}
