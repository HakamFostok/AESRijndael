using System.Collections.Generic;
using System.Linq;
using System;

namespace AesRijndaelLibrary
{
    public class Encryptor : IEncryptor
    {
        public string Encrypt128(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey128(keyBytes);
            return Encrypt(text, key, new Aes128(), keybase);
        }

        public string Encrypt192(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey192(keyBytes);
            return Encrypt(text, key, new Aes192(), keybase);
        }

        public string Encrypt256(string text, string key)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);
            AesKeyBase keybase = new AesKey256(keyBytes);
            return Encrypt(text, key, new Aes256(), keybase);
        }

        private string Encrypt(string text, string key, AesBase algo, AesKeyBase baseKey)
        {
            byte[] keyBytes = GetTheByteArrayOfTheKey(key);

            List<string> chuncks = PartitionTheTextTo32Chunck(text);
            byte[] input = HandleTheInput(chuncks);

            var encryptedOutput = algo.Encrypt(input.ToArray(), baseKey);

            return string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));
        }

        private static void GetHexadecimal(List<byte> bytes, string text)
        {
            try
            {
                for (int index = 0; index < text.Length; index += 2)
                {
                    bytes.Add(text.Substring(index, 2).GetByteFromHex());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                bytes.Add(text[^1].ToString().GetByteFromHex());
            }
        }

        private List<string> PartitionTheTextTo32Chunck(string textOfInput)
        {
            List<string> totalInput = new ();
            if (textOfInput.Length % 32 != 0)
                textOfInput += new string(Enumerable.Repeat<char>('0', 32 - (textOfInput.Length % 32)).ToArray());

            for (int index = 0; index < textOfInput.Length / 32; index++)
                totalInput.Add(new string(textOfInput.Skip(32 * index).Take(32).ToArray()));

            return totalInput;
        }

        private byte[] HandleTheInput(List<string> list)
        {
            List<byte> bytesOfText = new();

            string text = list.Select(line => new string(line.Where(ch => !char.IsWhiteSpace(ch)).ToArray())).Aggregate((one, two) => one + two);
            GetHexadecimal(bytesOfText, text);

            // make the length of the bytes array multiplied by 16.
            while ((bytesOfText.Count % 16) != 0)
                bytesOfText.Add(0);

            return bytesOfText.ToArray();

        }

        private byte[] GetTheByteArrayOfTheKey(string key)
        {
            List<byte> bytesOfKey = new();

            GetHexadecimal(bytesOfKey, key);

            return bytesOfKey.ToArray();
        }
    }
}