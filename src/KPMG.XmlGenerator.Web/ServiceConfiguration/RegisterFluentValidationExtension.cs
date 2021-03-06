namespace KPMG.XmlGenerator.Web.Configuration
{
    using FluentValidation;

    using KPMG.XmlGenerator.Core.DTOs;
    using KPMG.XmlGenerator.Web.Validators.CgMetaAreaCreateDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaAreaDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaAreaToObjectDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaConfigurationCreateDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaConfigurationDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaConfigurationToVariantDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaObjectDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaVariantCreateDTO;
    using KPMG.XmlGenerator.Web.Validators.CgMetaVariantToObjectDTO;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// RegisterFluentValidationExtension class
    /// </summary>
    public static class RegisterFluentValidationExtension
    {
        /// <summary>
        /// Registers the register fluent validation extension.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterValidationServiceExtension(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<CgMetaAreaCreateDTO>, CgMetaAreaCreateValidator>();
            services.AddSingleton<IValidator<CgMetaAreaDTO>, CgMetaAreaValidator>();
            services.AddSingleton<IValidator<CgMetaObjectDTO>, CgMetaObjectValidator>();
            services.AddSingleton<IValidator<CgMetaObjectNameValidationDTO>, CgMetaObjectNameValidationDtoValidator>();
            services.AddSingleton<IValidator<CgMetaAreaToObjectDTO>, CgMetaAreaToObjectValidator>();
            services.AddSingleton<IValidator<CgMetaVariantCreateDTO>, CgMetaVariantCreateValidator>();
            services.AddSingleton<IValidator<CgMetaVariantDTO>, CgMetaVariantValidator>();
            services.AddSingleton<IValidator<CgMetaConfigurationDTO>, CgMetaConfigurationValidator>();
            services.AddSingleton<IValidator<CgMetaConfigurationCreateDTO>, CgMetaConfigurationCreateValidator>();
            services.AddSingleton<IValidator<CgMetaVariantToObjectDTO>, CgMetaVariantToObjectValidator>();
            services.AddSingleton<IValidator<CgMetaConfigurationToVariantDTO>, CgMetaConfigurationToVariantValidator>();
        }
    }
}

