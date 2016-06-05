using System;

namespace Aps.Domain.Customer.Tests
{
    public struct CreditCardNumber 
    {
        public CreditCardNumber(string cardNumber) : this()
        {

            Console.WriteLine(cardNumber);

            int length = cardNumber.Length;

            if (length != 16)
            {
                throw new NotImplementedException();
            }
        }
    }
}
