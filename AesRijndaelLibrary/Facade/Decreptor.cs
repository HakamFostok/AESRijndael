using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary;

[Obsolete]
public class Decreptor : EncryptDecreptBase, IDecreptor
{
    public string Decrept128(string text, string key)
    {
        byte[] keyBytes = GetTheByteArrayOfTheKey(key);
        AesKeyBase keybase = new AesKey128(keyBytes);
        return Decrept(text, keybase);
    }

    public string Decrept192(string text, string key)
    {
        byte[] keyBytes = GetTheByteArrayOfTheKey(key);
        AesKeyBase keybase = new AesKey192(keyBytes);
        return Decrept(text, keybase);
    }

    public string Decrept256(string text, string key)
    {
        byte[] keyBytes = GetTheByteArrayOfTheKey(key);
        AesKeyBase keybase = new AesKey256(keyBytes);
        return Decrept(text, keybase);
    }

    public string Decrept(string text, AesKeyBase baseKey)
    {
        AesBase algo = baseKey switch
        {
            AesKey128 => new Aes128(),
            AesKey192 => new Aes192(),
            AesKey256 => new Aes256(),
            _ => throw new InvalidCastException("type is not supported"),
        };

        return Decrept(text, algo, baseKey);
    }

    private string Decrept(string text, AesBase algo, AesKeyBase baseKey)
    {
        List<string> chuncks = PartitionTheTextTo32Chunck(text);
        byte[] input = HandleTheInput(chuncks);

        byte[] encryptedOutput = algo.Decrypt(input.ToArray(), baseKey);

        return string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));
    }
}
