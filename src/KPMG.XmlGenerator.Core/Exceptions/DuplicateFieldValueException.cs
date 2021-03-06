namespace KPMG.XmlGenerator.Core.Exceptions
{
    public class DuplicateFieldValueException : XmlGeneratorException
    {
        public override string Message => "Please enter unique {0}.";

        public override string Source => "1";
    }
}
