namespace AesRijndaelLibrary;

public interface IDecreptor
{
    string Decrept(string text, AesKeyBase baseKey);
    string Decrept128(string text, string key);
    string Decrept192(string text, string key);
    string Decrept256(string text, string key);
}
