namespace KPMG.XmlGenerator.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using KPMG.XmlGenerator.Core.Models;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    public static class DbSqlScriptsHelper
    {
        private const string embeddedResource_StoredProcedures_Prefix = "KPMG.XmlGenerator.Data.DB_Scripts.usp_";
        private const string embeddedResource_SchemaChanges_Prefix = "KPMG.XmlGenerator.Data.DB_Scripts.SchemaChange_";

        public static IEnumerable<DbSqlScriptExecutionResult> ApplyAllSqlScripts(string connectionString)
        {
            string[] allResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            string[] schemaChangeFiles = allResourceNames.Where(n => n.StartsWith(embeddedResource_SchemaChanges_Prefix)).ToArray();
            string[] storedProcedureFiles = allResourceNames.Where(n => n.StartsWith(embeddedResource_StoredProcedures_Prefix)).ToArray();

            DbSqlScriptExecutionResult[] result = new DbSqlScriptExecutionResult[schemaChangeFiles.Length + storedProcedureFiles.Length];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Server server = new Server(new ServerConnection(connection));

                for (int i = 0; i < schemaChangeFiles.Length; i++)
                {
                    result[i] = ExecuteSqlScriptFromEmbeddedResource(server.ConnectionContext, schemaChangeFiles[i]);
                }
                for (int i = 0; i < storedProcedureFiles.Length; i++)
                {
                    result[i + schemaChangeFiles.Length] = ExecuteSqlScriptFromEmbeddedResource(server.ConnectionContext, storedProcedureFiles[i]);
                }
            }

            return result;
        }

        private static DbSqlScriptExecutionResult ExecuteSqlScriptFromEmbeddedResource(ServerConnection smoServerConnection, string resourceName)
        {
            var result = new DbSqlScriptExecutionResult()
            {
                DbSqlScriptFileName = resourceName
            };

            try
            {
                smoServerConnection.ExecuteNonQuery(ReadResource(resourceName));
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.ExecutionResult = ex.ToString();
            }

            return result;
        }

        private static string ReadResource(string resourceName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
