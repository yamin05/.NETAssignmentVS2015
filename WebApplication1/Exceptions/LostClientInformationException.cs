using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class LostClientInformationException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public LostClientInformationException()
        {
            errorCode = 182;
            errorMessage = "Lost the information of Client";
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