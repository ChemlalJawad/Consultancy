using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Exceptions
{
    public class ValidException : Exception
    {
        public ValidException(string message) : base(message) { }
    }
}
