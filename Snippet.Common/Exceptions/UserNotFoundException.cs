using System;

namespace Snippet.Common.Exceptions
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}