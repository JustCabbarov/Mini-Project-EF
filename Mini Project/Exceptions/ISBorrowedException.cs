﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Exceptions
{
    public class ISBorrowedException : Exception

    {
        public ISBorrowedException()
        {
        }

        public ISBorrowedException(string? message) : base(message)
        {
        }
    }
}
