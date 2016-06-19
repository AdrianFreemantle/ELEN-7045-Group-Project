using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Credential;

namespace Aps.Domain.Customer.Tests
{
    public partial class TelephoneNumber
    {

        private Exception thrownError;
        private string phoneNumber;


        private void a_telephone_number(string number)
        {
            phoneNumber = number;
            thrownError = null;
        }

        private void creating_a_telephone_number_value_object()
        {
            try
            {
                var pn = new TelePhoneNumber(phoneNumber);
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
