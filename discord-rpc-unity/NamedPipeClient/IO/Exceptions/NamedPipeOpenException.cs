using System;

namespace Lachee.IO.Exceptions
{
    public class NamedPipeOpenException : Exception
    {
        internal NamedPipeOpenException(int err) : base(
            "An exception has occured while trying to open the pipe. Error Code: " + err)
        {
            ErrorCode = err;
        }

        public int ErrorCode { get; private set; }
    }
}