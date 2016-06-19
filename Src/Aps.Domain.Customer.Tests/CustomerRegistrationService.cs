using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Customer.Tests
{
    public class CustomerRegistrationService
    {

        private string username;

        public CustomerRegistrationService(string Username)
        {
            Console.WriteLine("Inside  factory :" + Username);
        }
    }
}
