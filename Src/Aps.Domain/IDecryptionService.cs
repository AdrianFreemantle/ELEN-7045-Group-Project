namespace Aps.Domain
{
    public interface IDecryptionService
    {
        string Decrypt(byte[] data);
    }
}
