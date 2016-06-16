namespace Aps.Domain
{
    public interface IEncryptionService
    {
        byte[] Encrypt(string data);
    }
}
