using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class CannotEditStatusException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public CannotEditStatusException()
        {
            errorCode = 112;
            errorMessage = "You Cannot Change the status of this intervention";
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