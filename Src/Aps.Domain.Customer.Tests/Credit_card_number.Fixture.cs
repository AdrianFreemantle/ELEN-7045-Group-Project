using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Customer.Tests
{
    public partial class Credit_card_number
    {
        private Exception thrownError;
        private string cardNumber;

        //arrange - configure
        private void a_credit_card_number(string number)
        {
            cardNumber = number;
            thrownError = null;
        }

        //act - do
        private void creating_a_credit_card_number_value_object()
        {
            try
            {
                var cc = new CreditCardNumber(cardNumber);
            }
            catch (Exception ex)
            {
                thrownError = ex;
            }
        }

        //assert - validate
        private void success()
        {
            if (thrownError != null)
            {
                throw thrownError;
            }
        }
    }
}
