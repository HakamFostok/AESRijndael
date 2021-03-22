using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;
using System.Linq;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes256UnitTest
    {
        private const string INPUT = "00112233445566778899AABBCCDDEEFF";
        private const string OUTPUT = "8EA2B7CA516745BFEAFC49904B496089";
        private const string KEY = "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f";

        [TestMethod]
        public void Aes256_Encrypt_Success()
        {
            Encryptor encryptor = new();
            string outputByte = encryptor.Encrypt256(INPUT, KEY);
            Assert.AreEqual(OUTPUT, outputByte);
        }

        [TestMethod]
        public void Aes256_Decrypt_Success()
        {
            Decreptor encryptor = new();
            string outputByte = encryptor.Decrept256(OUTPUT, KEY);
            Assert.AreEqual(INPUT, outputByte);
        }

        [TestMethod]
        public void Aes256_EncryptAndDecrept_Success()
        {
            Encryptor encryptor = new();
            Decreptor decreptor = new();
            string input = "00987ABCDEF1234";
            string encreptedOutput = encryptor.Encrypt128(input, KEY);
            string decreptedOutput = decreptor.Decrept128(encreptedOutput, KEY);

            Assert.AreEqual(input, new string(decreptedOutput.Take(input.Length).ToArray()));
        }
    }
}
