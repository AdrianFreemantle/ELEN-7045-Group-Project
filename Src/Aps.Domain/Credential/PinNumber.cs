using System;

namespace Aps.Domain.Credential
{
    class PinNumber : ISecurityField
    {
        private readonly byte[] encryptedData;

        public PinNumber(string pin, string confirmpin, IEncryptionService encryptionService)
        {
            if (String.IsNullOrWhiteSpace(pin) || String.IsNullOrWhiteSpace(confirmpin))
                throw new Exception();

            if (pin != confirmpin)
                throw new Exception();

            encryptedData = encryptionService.Encrypt(pin);
        }

        public string GetDetails(IDecryptionService decryptionService)
        {
            return decryptionService.Decrypt(encryptedData);
        }
    }
}
