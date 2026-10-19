using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class LicenseExpiredException : Exception
    {
        public LicenseExpiredException(string message) : base(message)
        {
            
        }
    }
}
