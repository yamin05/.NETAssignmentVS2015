using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class FailedToCreateClientOrIntervention : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public FailedToCreateClientOrIntervention()
        {
            errorCode = 108;
            errorMessage = "Failed to create a client/Intervention in database";
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