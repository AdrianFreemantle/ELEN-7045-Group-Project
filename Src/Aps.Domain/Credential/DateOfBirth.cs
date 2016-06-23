using System;

namespace Aps.Domain.Credential
{
    public struct DateOfBirth : IIdentificationField
    {
        private readonly byte[] encryptedData;

        public DateOfBirth(DateTime dateofbirth, IEncryptionService encryptionService)
        {
            Guard.ThatValueTypeNotDefaut(dateofbirth, "Date Of Birth");

            if (dateofbirth > DateTime.Now)
            {
                throw new DomainException("Date Of Birth Credential", "Invalid Date Of Birth Passed");
            }

            encryptedData = encryptionService.Encrypt(dateofbirth.Ticks.ToString());
        }

        public DateTime GetDateTime(IDecryptionService decryptionService)
        {
            return new DateTime(long.Parse(decryptionService.Decrypt(encryptedData)));
        }
    }
}