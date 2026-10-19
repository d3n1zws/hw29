using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message) : base(message)
        {
             
        }
    }
}
