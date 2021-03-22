using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes192UnitTest
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

        private byte[] HandleTheKey192()
        {
            // get the key
            List<byte> bytesOfKey = new List<byte>();

            var key = "000102030405060708090a0b0c0d0e0f1011121314151617";
            GetHexadecimal(bytesOfKey, key);

            return bytesOfKey.ToArray();
        }

        //000102030405060708090a0b0c0d0e0f1011121314151617
        //00112233445566778899aabbccddeeff
        //DDA97CA4864CDFE06EAF70A0EC0D7191
        [TestMethod]
        public void Aes192_Encrypt_Success()
        {
            Aes192 algo = new();
            byte[] key = HandleTheKey192();

            var text = "00112233445566778899AABBCCDDEEFF";
            var input = HandleTheInput(PartitionTheTextTo32Chunck(text));
            
            var encryptedOutput = algo.Encrypt(input.ToArray(), new AesKey192(key));

            string outputByte = string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));

            string expectedOutput = "DDA97CA4864CDFE06EAF70A0EC0D7191";
            Assert.AreEqual(expectedOutput, outputByte);
        }

        [TestMethod]
        public void Aes192_Decrypt_Success()
        {
            Aes192 algo = new();
            byte[] key = HandleTheKey192();

            var text = "DDA97CA4864CDFE06EAF70A0EC0D7191";
            var input = HandleTheInput(PartitionTheTextTo32Chunck(text));

            var encryptedOutput = algo.Decrypt(input.ToArray(), new AesKey192(key));

            string outputByte = string.Join("", encryptedOutput.Select(oneByte => oneByte.GetHexadecimal()));

            string expectedOutput = "00112233445566778899AABBCCDDEEFF";
            Assert.AreEqual(expectedOutput, outputByte);
        }
    }
}