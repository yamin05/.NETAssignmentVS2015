using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Exceptions
{
    public class ExcedesAllowedCostException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public ExcedesAllowedCostException()
        {
            errorCode = 101;
            errorMessage = "Cost to be allocated is exceding the allowed Cost";
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