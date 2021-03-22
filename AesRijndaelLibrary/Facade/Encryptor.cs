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
            return Encrypt(text, new Aes128(), keybase);
        }

        public string Encrypt192(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey192(keyBytes);
            return Encrypt(text, new Aes192(), keybase);
        }

        public string Encrypt256(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey256(keyBytes);
            return Encrypt(text, new Aes256(), keybase);
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