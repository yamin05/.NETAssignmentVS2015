using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class WrongCurrentPassword : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public WrongCurrentPassword()
        {
            errorCode = 11;
            errorMessage = "The Curent Password doesn't match the database";
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