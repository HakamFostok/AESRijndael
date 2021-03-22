using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes256UnitTest
    {
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
            List<string> totalInput = new List<string>();
            if (textOfInput.Length % 32 != 0)
                textOfInput += new string(Enumerable.Repeat<char>('0', 32 - (textOfInput.Length % 32)).ToArray());

            for (int index = 0; index < textOfInput.Length / 32; index++)
                totalInput.Add(new string(textOfInput.Skip(32 * index).Take(32).ToArray()));

            return totalInput;
        }

        private byte[] HandleTheInput(List<string> list)
        {
            List<byte> bytesOfText = new List<byte>();

            string text = list.Select(line => new string(line.Where(ch => !char.IsWhiteSpace(ch)).ToArray())).Aggregate((one, two) => one + two);
            GetHexadecimal(bytesOfText, text);

            // make the length of the bytes array multiplied by 16.
            while ((bytesOfText.Count % 16) != 0)
                bytesOfText.Add(0);

            return bytesOfText.ToArray();

        }

        private byte[] HandleTheKey256()
        {
            // get the key
            List<byte> bytesOfKey = new List<byte>();

            var key = "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f";
            GetHexadecimal(bytesOfKey, key);

            return bytesOfKey.ToArray();
        }

        //000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
        //00112233445566778899aabbccddeeff
        //8EA2B7CA516745BFEAFC49904B496089

        [TestMethod]
        public void Aes256_Encrypt_Success()
        {
            Encryptor encryptor = new();
            var outputByte = encryptor.Encrypt256("00112233445566778899aabbccddeeff",
                "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");

            string expectedOutput = "8EA2B7CA516745BFEAFC49904B496089";
            Assert.AreEqual(expectedOutput, outputByte);
        }

        [TestMethod]
        public void Aes256_Decrypt_Success()
        {
            Aes256 algo = new();
            byte[] key = HandleTheKey256();
            var text = "8EA2B7CA516745BFEAFC49904B496089";
            var input = HandleTheInput(PartitionTheTextTo32Chunck(text));

            var encryptedOutput = algo.Decrypt(input.ToArray(), new AesKey256(key));

            string outputByte = string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));

            string expectedOutput = "00112233445566778899AABBCCDDEEFF";
            Assert.AreEqual(expectedOutput, outputByte);
        }
    }
}
