using System;

namespace Aps.Domain.Credential
{
    public struct Password : ISecurityField
    {
        private readonly byte[] encryptedData;

        public Password(string password, string confirmpassword, IEncryptionService encryptionService)
        {
            Guard.ThatParameterNotNullOrEmpty(password, "Password");
            Guard.ThatParameterNotNullOrEmpty(confirmpassword, "Confirm Password");

            if (password != confirmpassword)
                throw new DomainException("Password Credential", "Password and Confirm Password does not match");

            encryptedData = encryptionService.Encrypt(password);
        }

        public string GetDetails(IDecryptionService decryptionService)
        {
            return decryptionService.Decrypt(encryptedData);
        }
    }
}
