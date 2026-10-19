using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class RentalAlreadyCompletedException : Exception
    {
        public RentalAlreadyCompletedException(string message) : base(message)
        {
            
        }
    }
}
