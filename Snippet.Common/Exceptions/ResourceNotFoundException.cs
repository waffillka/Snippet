using System;

namespace Snippet.Common.Exceptions
{
    public class ResourceNotFoundException : ApplicationException
    {
        public ResourceNotFoundException(string message) : base(message)
        {
        }
    }
}