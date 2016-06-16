using System.Linq;

namespace Aps.Domain.Common
{
    internal struct CreditCardCredential  : ICredential
    {
        private string creditcardCredential;

        private CreditCardCredential(string creditcardCredential)
        {
            this.creditcardCredential = creditcardCredential;
        }

        public bool IsValid()
        {
            if (creditcardCredential.Length != 16)
                return false;

            return creditcardCredential.All(c => c >= '0' && c <= '9');
        }
    }
}