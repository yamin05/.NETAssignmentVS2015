using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class InterventionAdditionConflictExpection : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public InterventionAdditionConflictExpection()
        {
            errorCode = 187;
            errorMessage = "There are some conflictions about Intervention Addition";
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