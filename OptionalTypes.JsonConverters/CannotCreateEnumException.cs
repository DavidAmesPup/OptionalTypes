using System;


namespace OptionalTypes.JsonConverters
{
    [Serializable]
    public class CannotCreateEnumException : Exception
    {
     
        public CannotCreateEnumException()
        {
        }

        public CannotCreateEnumException(string message) : base(message)
        {
        }

        public CannotCreateEnumException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CannotCreateEnumException(object value, Type targetType) : this($"{value} is not a valid enum value for {targetType.Name}")
        {
           
        }

       
    }
}