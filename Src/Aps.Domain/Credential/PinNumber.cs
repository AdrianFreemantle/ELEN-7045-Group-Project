using System;

namespace Aps.Domain.Credential
{
    class PinNumber : ISecurityField
    {
        private readonly byte[] encryptedData;

        public PinNumber(string pin, string confirmpin, IEncryptionService encryptionService)
        {
            if (String.IsNullOrWhiteSpace(pin) || String.IsNullOrWhiteSpace(confirmpin))
                throw new DomainException("Pin Number Credential", "Invalid Pin Number passed");

            if (pin != confirmpin)
                throw new DomainException("Pin Number Credential", "Pin Number and Confirm Pin Number does not match");
            
            encryptedData = encryptionService.Encrypt(pin);
        }

        public string GetDetails(IDecryptionService decryptionService)
        {
            return decryptionService.Decrypt(encryptedData);
        }
    }
}
