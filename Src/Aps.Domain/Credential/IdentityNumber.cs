namespace Aps.Domain.Credential
{
    internal struct IdentityNumber : ICredential
    {
        private string _identityNumber;

        private IdentityNumber(string identityNumber)
        {
            if (!Validator.IdentityNumberIsValid(identityNumber))
            {
                throw new DomainException("Identity Number Credential", "Invalid Identity Number Passed");
            }

            this._identityNumber = identityNumber;
        }
    }
}