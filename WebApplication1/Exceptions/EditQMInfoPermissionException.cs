using System;

namespace WebApplication1.Exceptions
{
    public class EditQMInfoPermissionException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public EditQMInfoPermissionException()
        {
            errorCode = 115;
            errorMessage = "You don't have enough permission to change the Quality Management Information of this intervention";
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