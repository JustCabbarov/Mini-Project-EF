using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Exceptions
{
    public class SameDataException : Exception
    {
        public SameDataException()
        {
        }

        public SameDataException(string? message) : base(message)
        {
        }
    }
}
