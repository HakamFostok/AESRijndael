using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary
{
    public class Decreptor : EncryptDecreptBase, IDecreptor
    {
        public string Decrept128(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey128(keyBytes);
            return Decrept(text, new Aes128(), keybase);
        }

        public string Decrept192(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey192(keyBytes);
            return Decrept(text, new Aes192(), keybase);
        }

        public string Decrept256(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey256(keyBytes);
            return Decrept(text, new Aes256(), keybase);
        }

        private string Decrept(string text, AesBase algo, AesKeyBase baseKey)
        {
            List<string> chuncks = PartitionTheTextTo32Chunck(text);
            byte[] input = HandleTheInput(chuncks);

            var encryptedOutput = algo.Decrypt(input.ToArray(), baseKey);

            return string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));
        }


    }
}