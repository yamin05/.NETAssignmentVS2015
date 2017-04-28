using System;

namespace WebApplication1.Exceptions
{
    public class EditStatusPermissionException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public EditStatusPermissionException()
        {
            errorCode = 113;
            errorMessage = "You don't have enough permission to change the status";
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