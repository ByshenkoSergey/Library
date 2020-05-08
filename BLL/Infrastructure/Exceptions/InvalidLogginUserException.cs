using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure.Exceptions
{
    public class InvalidLogginUserException:Exception
    {
        public override string Message { get;}
        public InvalidLogginUserException(string message) : base(message)
        {
            Message = message;
        }
    }
}
