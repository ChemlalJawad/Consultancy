using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Exceptions
{
    public class NotValidException : Exception
    {
        public NotValidException(string message) : base(message) { }
    }
}
