using System;

namespace Behlog.Core.Exceptions
{
    public class BehlogException: Exception
    {
        public BehlogException() : base() { }

        public BehlogException(string message): base(message) { }
    }
}
