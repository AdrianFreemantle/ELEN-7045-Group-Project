using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Customer.Tests
{
    public partial class CcvNumber
    {

        private string ccvNumber;
        private Exception thrownError;

        private void a_ccv_number(string s)
        {

            Console.WriteLine(s);

            ccvNumber = s;
            thrownError = null;   
        }

        private void creating_a_ccv_number_value_object()
        {

            try
            {
                var ccv = new Ccv(ccvNumber);
            }
            catch (Exception ex)
            {
                thrownError = ex;
            }

        }

        private void Success()
        {

            if (thrownError != null)
            {
                throw thrownError;
            }
            
        }
    }
}
