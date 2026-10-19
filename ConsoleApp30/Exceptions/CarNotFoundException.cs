using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException(string message) : base(message)
        {
            
        }
    }
}
