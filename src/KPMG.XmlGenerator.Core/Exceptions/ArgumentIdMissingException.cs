namespace KPMG.XmlGenerator.Core.Exceptions
{
    using System;

    /// <summary>
    /// ArgumentIdMissingException class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ArgumentIdMissingException : Exception
    {
        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message => "No {0} was selected to update mapping ";

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public override string Source => "1";
    }
}
