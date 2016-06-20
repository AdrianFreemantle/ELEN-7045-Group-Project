using Aps.Domain.Credential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Common;

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
                IEncryptionService service = new Encryption();
                var cc = new CreditCardNumber(cardNumber, service);
                
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
