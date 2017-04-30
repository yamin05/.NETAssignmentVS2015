using System;

namespace WebApplication1.Exceptions
{
    public class InvalidConditionUpdateException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public InvalidConditionUpdateException()
        {
            errorCode = 117;
            errorMessage = "The Condition Cannot Excede The Previos Update";
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