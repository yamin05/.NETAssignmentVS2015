using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class WrongInputPasswordException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public WrongInputPasswordException()
        {
            errorCode = 107;
            errorMessage = "The user password doesn't match with the database";
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