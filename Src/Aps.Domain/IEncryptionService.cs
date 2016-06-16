namespace Aps.Domain
{
    interface IEncryptionService
    {
        byte[] Encrypt(string data);
    }
}
