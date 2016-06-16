using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Customer.Tests
{
    public struct Ccv
    {
        public Ccv(string ccvNumber)
        {
            Console.WriteLine(ccvNumber);

            int ccv_length = ccvNumber.Length;

            if (ccv_length != 3)
            {
                throw new NotImplementedException();
            }

        }
    }
}
