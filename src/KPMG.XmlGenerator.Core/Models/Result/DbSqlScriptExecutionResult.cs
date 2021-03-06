namespace KPMG.XmlGenerator.Core.Models
{
    public class DbSqlScriptExecutionResult
    {
        public string DbSqlScriptFileName { get; set; }

        public string ExecutionResult { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
