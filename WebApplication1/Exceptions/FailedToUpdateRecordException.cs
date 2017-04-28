using System;

namespace WebApplication1.Exceptions
{
    public class FailedToUpdateRecordException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public FailedToUpdateRecordException()
        {
            errorCode = 114;
            errorMessage = "Failed to update a record in database";
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