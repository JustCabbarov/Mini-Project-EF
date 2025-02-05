using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Exceptions
{
    public class InvalidTimeException : Exception
    {
        public InvalidTimeException()
        {
        }

        public InvalidTimeException(string? message) : base(message)
        {
        }
    }
}
