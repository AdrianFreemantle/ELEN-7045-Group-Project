using System.Linq;

namespace Aps.Domain.Credential
{
    public struct CreditCardNumber  : IIdentificationField
    {
        private readonly byte[] encryptedData;

        public CreditCardNumber(string creditcardnumber, IEncryptionService encryptionService)
        {
            Guard.ThatParameterNotNullOrEmpty(creditcardnumber, "Credit Card Number");

            if (creditcardnumber.Length != 16)
            {
                throw new DomainException("Credit Card Credential", "Invalid Credit Card Number passed");
            }
            if (!creditcardnumber.All(c => c >= '0' && c <= '9'))
            {
                throw new DomainException("Credit Card Credential", "Invalid Credit Card Number passed");
            }


            encryptedData = encryptionService.Encrypt(creditcardnumber);
        }

        public string GetDetails(IDecryptionService decryptionService)
        {
            return decryptionService.Decrypt(encryptedData);
        }
    }
}