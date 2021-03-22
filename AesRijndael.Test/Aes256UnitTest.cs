using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes256UnitTest
    {
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
            Decreptor encryptor = new();
            var outputByte = encryptor.Decrept256("8EA2B7CA516745BFEAFC49904B496089",
                "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");

            string expectedOutput = "00112233445566778899AABBCCDDEEFF";
            Assert.AreEqual(expectedOutput, outputByte);
        }
    }
}
