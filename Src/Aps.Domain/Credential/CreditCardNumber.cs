namespace Aps.Domain.Credential
{
    internal struct CreditCardNumber  : ICredential
    {
        private string _creditcardnumber;

        private CreditCardNumber(string creditcardnumber)
        {
            if (!Validator.CreditCardIsValid(creditcardnumber))
            {
                throw new DomainException("Credit Card Credential", "Invalid Credit Card Number passed");
            }

            this._creditcardnumber = creditcardnumber;
        }
    }
}