namespace Aps.Domain.Credential
{
    public struct CreditCardNumber  : IIdentificationField
    {
        private readonly string _creditcardnumber;

        public CreditCardNumber(string creditcardnumber)
        {
            Guard.ThatParameterNotNullOrEmpty(creditcardnumber, "Credit Card Number");
            if (!Validator.CreditCardIsValid(creditcardnumber))
            {
                throw new DomainException("Credit Card Credential", "Invalid Credit Card Number passed");
            }

            this._creditcardnumber = creditcardnumber;
        }

        public override string ToString()
        {
            return _creditcardnumber;
        }

        //To-Do Add encryption 
    }
}