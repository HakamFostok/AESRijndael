namespace AesRijndaelLibrary
{
    public interface IEncryptor
    {
        string Encrypt(string text, AesKeyBase baseKey);
        string Encrypt128(string text, string key);
        string Encrypt192(string text, string key);
        string Encrypt256(string text, string key);
    }
}