﻿using System;

namespace component.exception
{
    public class UnauthorizedCustomException : Exception
    {
        public string ErrorCode { get; set; }
        public UnauthorizedCustomException(string message) : base(message)
        { }

        public UnauthorizedCustomException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
