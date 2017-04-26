using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class WrongUserInputException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public WrongUserInputException()
        {
            errorCode = 108;
            errorMessage = "The user input doesn't match with the database";
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