namespace KPMG.XmlGenerator.Core.DTOs
{
    using System.Collections.Generic;

    public class ServerValidationResult
    {
        public ServerValidationResult()
        {

        }

        public ServerValidationResult(bool isValidationSuccessful, params string[] validationErrors)
        {
            this.IsValidationSuccessful = isValidationSuccessful;
            this.ValidationErrors = validationErrors;
        }

        public bool IsValidationSuccessful { get; set; }

        public IEnumerable<string> ValidationErrors { get; set; }
    }
}
