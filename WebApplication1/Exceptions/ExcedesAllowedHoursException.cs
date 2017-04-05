using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class ExcedesAllowedHoursException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public ExcedesAllowedHoursException()
        {
            errorCode = 100;
            errorMessage = "Hours to be allocated is exceding the allowed hours";
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