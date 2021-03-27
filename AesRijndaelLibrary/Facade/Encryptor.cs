using System.Collections.Generic;
using System.Linq;
using System;

namespace AesRijndaelLibrary
{
    public class Encryptor : EncryptDecreptBase, IEncryptor
    {
        public string Encrypt128(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey128(keyBytes);
            return Encrypt(text, keybase);
        }

        public string Encrypt192(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey192(keyBytes);
            return Encrypt(text, keybase);
        }

        public string Encrypt256(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey256(keyBytes);
            return Encrypt(text, keybase);
        }

        public string Encrypt(string text, AesKeyBase baseKey)
        {
            AesBase algo = baseKey switch
            {
                AesKey128 => new Aes128(),
                AesKey192 => new Aes192(),
                AesKey256 => new Aes256(),
                _ => throw new InvalidCastException("type is not supported"),
            };

            return Encrypt(text, algo, baseKey);
        }

        private string Encrypt(string text, AesBase algo, AesKeyBase baseKey)
        {
            List<string> chuncks = PartitionTheTextTo32Chunck(text);
            byte[] input = HandleTheInput(chuncks);

            var encryptedOutput = algo.Encrypt(input.ToArray(), baseKey);

            return string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));
        }
    }
}