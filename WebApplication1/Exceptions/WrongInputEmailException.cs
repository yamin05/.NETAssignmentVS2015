using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class WrongInputEmailException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public WrongInputEmailException()
        {
            errorCode = 106;
            errorMessage = "The user email doesn't match with the database";
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