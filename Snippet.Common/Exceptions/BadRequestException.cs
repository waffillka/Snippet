using System;

namespace Snippet.Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg) : base(msg)
        {
        }
    }
}
