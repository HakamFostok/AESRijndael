using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes128UnitTest
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

        private byte[] HandleTheKey128()
        {
            // get the key
            List<byte> bytesOfKey = new List<byte>();

            var key = "000102030405060708090a0b0c0d0e0f";
            GetHexadecimal(bytesOfKey, key);

            return bytesOfKey.ToArray();
        }

        [TestMethod]
        public void Aes128_Encrypt_Success()
        {
            Encryptor encryptor = new();
            var outputByte =  encryptor.Encrypt128("00112233445566778899aabbccddeeff",
                "000102030405060708090a0b0c0d0e0f");

            string expectedOutput = "69C4E0D86A7B0430D8CDB78070B4C55A";
            Assert.AreEqual(expectedOutput, outputByte);
        }

        //000102030405060708090a0b0c0d0e0f
        //00112233445566778899aabbccddeeff
        //69C4E0D86A7B0430D8CDB78070B4C55A
        [TestMethod]
        public void Aes128_Decrypt_Success()
        {
            Aes128 algo = new Aes128();
            byte[] key = HandleTheKey128();
            
            var text = "69C4E0D86A7B0430D8CDB78070B4C55A";
            var input = HandleTheInput(PartitionTheTextTo32Chunck(text));

            var encryptedOutput = algo.Decrypt(input.ToArray(), new AesKey128(key));

            string outputByte = string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));

            string expectedOutput = "00112233445566778899AABBCCDDEEFF";
            Assert.AreEqual(expectedOutput, outputByte);
        }
    }
}
