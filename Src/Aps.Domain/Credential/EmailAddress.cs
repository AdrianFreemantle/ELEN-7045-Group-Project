namespace Aps.Domain.Credential
{
    internal struct EmailAddress : IIdentificationField
    {
        private readonly string _address;

        private EmailAddress(string address)
        {
            Guard.ThatParameterNotNullOrEmpty(address, "Email Address"); 
            if (!Validator.EmailIsValid(address))
            {
                throw new DomainException("Email Credential", "Invalid Email Address passed");
            }

            this._address = address;
        }

        public override string ToString()
        {
            return _address;
        }
    }
}