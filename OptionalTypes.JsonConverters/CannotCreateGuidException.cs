using System;

namespace OptionalTypes.JsonConverters
{
    [Serializable]
    public class CannotCreateGuidException : Exception
    {
        public CannotCreateGuidException()
        {
        }

        public CannotCreateGuidException(string message) : base(message)
        {
        }

        public CannotCreateGuidException(object value) : this($"{value} is not a valid guid.")
        {
        }

        public CannotCreateGuidException(string message,
            Exception innerException) : base(message, innerException)
        {
        }
    }
}