using System;

namespace Snippet.Common.Exceptions
{
    public class DeprecatedOperationException : Exception
    {
        public DeprecatedOperationException(string message) : base(message)
        {
        }

        public DeprecatedOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DeprecatedOperationException()
        {
        }
    }
}