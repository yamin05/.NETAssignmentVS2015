﻿using System;

namespace WebApplication1.Exceptions
{
    public class CannotEditStatusException : Exception
    {
        private int errorCode { get; set; }
        private string errorMessage { get; set; }

        public CannotEditStatusException()
        {
            errorCode = 112;
            errorMessage = "The status is not editable from the current state";
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