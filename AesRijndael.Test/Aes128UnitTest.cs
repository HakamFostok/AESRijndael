using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes128UnitTest
    {
        [TestMethod]
        public void Aes128_Encrypt_Success()
        {
            Encryptor encryptor = new();
            var outputByte = encryptor.Encrypt128("00112233445566778899aabbccddeeff",
                "000102030405060708090a0b0c0d0e0f");

            string expectedOutput = "69C4E0D86A7B0430D8CDB78070B4C55A";
            Assert.AreEqual(expectedOutput, outputByte);
        }

        [TestMethod]
        public void Aes128_Decrypt_Success()
        {
            Decreptor encryptor = new();
            var outputByte = encryptor.Decrept128("69C4E0D86A7B0430D8CDB78070B4C55A",
                "000102030405060708090a0b0c0d0e0f");

            string expectedOutput = "00112233445566778899AABBCCDDEEFF";
            Assert.AreEqual(expectedOutput, outputByte);
        }
    }
}
