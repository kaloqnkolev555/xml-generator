namespace KPMG.XmlGenerator.Core.Exceptions
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ArgumentNameMissingException : Exception
    {
        public override string Message => "{0} is missing.";

        public override string Source => "1";
    }
}
