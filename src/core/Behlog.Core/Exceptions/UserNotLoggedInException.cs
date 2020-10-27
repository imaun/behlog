using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Core.Exceptions
{
    public class UserNotLoggedInException : BehlogException
    {
        public UserNotLoggedInException() {
        }

        public UserNotLoggedInException(string message) : base(message) {
        }
    }
}
