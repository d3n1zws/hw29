using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Exceptions
{
    public class PaymentExceedsDebtException : Exception
    {
        public PaymentExceedsDebtException(string message) : base(message)
        {
            
        }
    }
}
