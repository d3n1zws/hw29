using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class InvalidRentalDateException : Exception
    {
        public InvalidRentalDateException(string message) : base(message)
        {
            
        }
    }
}
