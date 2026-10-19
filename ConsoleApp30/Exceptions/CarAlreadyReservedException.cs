using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class CarAlreadyReservedException : Exception
    {
        public CarAlreadyReservedException(string message) : base(message)
        {
            
        }
    }
}
