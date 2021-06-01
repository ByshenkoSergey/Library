using System;


namespace BLL.Infrastructure.Exceptions
{
    public class InvalidLogginUserException : Exception
    {
        public override string Message { get; }
        public InvalidLogginUserException(string message) : base(message)
        {
            Message = message;
        }
    }
}
