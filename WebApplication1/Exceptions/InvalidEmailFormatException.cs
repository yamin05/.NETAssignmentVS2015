using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class InvalidPasswordFormatException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public InvalidPasswordFormatException()
        {
            errorCode = 105;
            errorMessage = "The format of the password is not valid";
        }

        public override string Message
        {
            get
            {
                return errorMessage;
            }
        }
    }
}