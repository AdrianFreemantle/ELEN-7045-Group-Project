using System;

namespace Aps.Domain.Credential
{
    class SecurityCode : ISecurityField
    {
        private readonly byte[] encryptedData;

        public SecurityCode(string code, string confirmcode, IEncryptionService encryptionService)
        {
            if (String.IsNullOrWhiteSpace(code) || String.IsNullOrWhiteSpace(confirmcode))
                throw new DomainException("Security Code Credential", "Invalid Security Code passed");

            if (code != confirmcode)
                throw new DomainException("Security Code Credential", "Security Code and Confirm Security Code does not match");

            encryptedData = encryptionService.Encrypt(code);
        }

        public string GetDetails(IDecryptionService decryptionService)
        {
            return decryptionService.Decrypt(encryptedData);
        }
    }
}
