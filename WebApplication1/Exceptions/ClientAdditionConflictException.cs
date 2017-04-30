using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions 
{
    public class ClientAdditionConflictException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public ClientAdditionConflictException()
        {
            errorCode = 187;
            errorMessage = "There are some conflictions about Client Addition";
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