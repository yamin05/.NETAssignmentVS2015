using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class ValueIsNullException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public ValueIsNullException()
        {
            errorCode = 103;
            errorMessage = "The value cannot be null";
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