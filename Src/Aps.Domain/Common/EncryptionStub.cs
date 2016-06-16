using System;

namespace Aps.Domain.Common
{
    public class EncryptionStub : IDecryptionService, IEncryptionService
    {
        public string Decrypt(byte[] data)

        {
            return String.Empty;
        }
        
        public byte[] Encrypt(string data)
        {
            return new byte[0];
        }
    }
}
