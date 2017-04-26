using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class FailedToCreateRecordException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public FailedToCreateRecordException()
        {
            errorCode = 110;
            errorMessage = "Failed to create a new record in database";
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