namespace KPMG.XmlGenerator.Data.Helpers
{
    using System;
    using System.Data.SqlClient;

    using KPMG.XmlGenerator.Core.Exceptions;

    /// <summary>
    /// SqlErrorCodeHelper class
    /// </summary>
    public static class SqlErrorCodeHelper
    {

        /// <summary>
        /// Parses the error.
        /// </summary>
        /// <param name="paramErrorCode">The parameter error code.</param>
        /// <exception cref="DuplicateFieldValueException"></exception>
        /// <exception cref="ArgumentNameMissingException"></exception>
        public static void ParseError(SqlParameter paramErrorCode)
        {
            if (paramErrorCode.Value != null && !DBNull.Value.Equals(paramErrorCode.Value))
            {
                int.TryParse(paramErrorCode.Value.ToString(), out int errorCode);

                if (errorCode.Equals(101) || errorCode.Equals(201) || errorCode.Equals(301) || errorCode.Equals(401))
                {
                    throw new ArgumentNameMissingException();
                }
                else if (errorCode.Equals(104) || errorCode.Equals(204) || errorCode.Equals(304) || errorCode.Equals(404))
                {
                    throw new ArgumentIdMissingException();
                }
                else if (errorCode.Equals(105) || errorCode.Equals(205) || errorCode.Equals(305) || errorCode.Equals(405))
                {
                    throw new DuplicateFieldValueException();
                }
            }
        }
    }
}
