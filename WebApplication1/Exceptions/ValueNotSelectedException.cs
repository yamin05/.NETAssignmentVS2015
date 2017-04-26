using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class ValueNotSelectedException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public ValueNotSelectedException()
        {
            errorCode = 111;
            errorMessage = "Please select a value first";
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