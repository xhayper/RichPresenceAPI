using System;

namespace Lachee.IO.Exceptions
{
    public class NamedPipeWriteException : Exception
    {
        internal NamedPipeWriteException(int err) : base(
            "An exception occured while reading from the pipe. Error Code: " + err)
        {
            ErrorCode = err;
        }

        public int ErrorCode { get; private set; }
    }
}