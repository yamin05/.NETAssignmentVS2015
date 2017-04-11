using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class InvalidEmailFormatException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public InvalidEmailFormatException()
        {
            errorCode = 104;
            errorMessage = "The format of the email address is not valid";
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