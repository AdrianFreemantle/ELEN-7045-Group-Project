using System.Linq;

namespace Aps.Domain.Common
{
    internal struct IdentityNumberCredential : ICredential
    {
        private string identityNumberCredential;

        private IdentityNumberCredential(string identityNumberCredential)
        {
            this.identityNumberCredential = identityNumberCredential;
        }

        public bool IsValid()
        {
            //Not sure if this should be where because what if a passport number can be an identity number
            if (identityNumberCredential.Length != 13)
                return false;

            return identityNumberCredential.All(c => c >= '0' && c <= '9');
        }
    }
}