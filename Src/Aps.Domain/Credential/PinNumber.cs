using System;

namespace Aps.Domain.Credential
{
    public struct PinNumber : ISecurityField
    {
        private readonly byte[] encryptedData;

        public PinNumber(string pin, string confirmpin, IEncryptionService encryptionService)
        {
            Guard.ThatParameterNotNullOrEmpty(pin, "Pin Number");
            Guard.ThatParameterNotNullOrEmpty(confirmpin, "Confirm Pin Number");

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
