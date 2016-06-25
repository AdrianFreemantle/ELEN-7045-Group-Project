using System.Linq;

namespace Aps.Domain.Credential
{
    public struct IdentityNumber : IIdentificationField
    {
        private readonly string _identityNumber;

        public IdentityNumber(string identityNumber)
        {
            Guard.ThatParameterNotNullOrEmpty(identityNumber, "Identity Number");

            if (identityNumber.Length != 13)
            {
                throw new DomainException("Identity Number Credential", "Invalid Identity Number Passed");
            }
            if (!identityNumber.All(c => c >= '0' && c <= '9'))
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