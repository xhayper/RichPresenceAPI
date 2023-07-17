﻿using System;

namespace Lachee.IO.Exceptions
{
    public class NamedPipeReadException : Exception
    {
        internal NamedPipeReadException(int err) : base(
            "An exception occured while reading from the pipe. Error Code: " + err)
        {
            ErrorCode = err;
        }

        public int ErrorCode { get; private set; }
    }
}