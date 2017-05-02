using System;


namespace WebApplication1.Exceptions
{
    public class FaliedToRetriveRecordException: Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public FaliedToRetriveRecordException()
        {
            errorCode = 189;
            errorMessage = "Failed to retrive record from database";
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