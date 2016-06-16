namespace Aps.Domain.Credential
{
    public struct IdentityNumber : IIdentificationField
    {
        private readonly string _identityNumber;

        private IdentityNumber(string identityNumber)
        {
            Guard.ThatParameterNotNullOrEmpty(identityNumber, "Identity Number"); 
            if (!Validator.IdentityNumberIsValid(identityNumber))
            {
                throw new DomainException("Identity Number Credential", "Invalid Identity Number Passed");
            }

            this._identityNumber = identityNumber;
        }

        public override string ToString()
        {
            return _identityNumber;
        }
    }
}