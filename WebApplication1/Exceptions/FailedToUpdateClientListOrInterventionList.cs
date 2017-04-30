using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class FailedToUpdateClientListOrInterventionList : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public FailedToUpdateClientListOrInterventionList()
        {
            errorCode = 114;
            errorMessage = "Failed to Update client/Intervention list";
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