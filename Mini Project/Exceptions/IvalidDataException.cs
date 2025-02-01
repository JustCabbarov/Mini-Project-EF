using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Exceptions
{

    public class IvalidDataException : Exception
    {
        public IvalidDataException()
        {
        }

        public IvalidDataException(string? message) : base(message)
        {
        }
    }
}
