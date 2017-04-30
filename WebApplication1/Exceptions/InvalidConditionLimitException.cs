using System;

namespace WebApplication1.Exceptions
{
    public class InvalidConditionLimitException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public InvalidConditionLimitException()
        {
            errorCode = 116;
            errorMessage = "The Condition Cannot Excede 100%";
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