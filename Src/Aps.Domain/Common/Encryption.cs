using System.Text;

namespace Aps.Domain.Common
{
    public class Encryption : IDecryptionService, IEncryptionService
    {
        public string Decrypt(byte[] data)
        {
            string s_unicode2 = Encoding.UTF8.GetString(data);
            return s_unicode2;
        }
        
        public byte[] Encrypt(string data)
        {
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(data);
            return utf8Bytes;
        }
    }
}
