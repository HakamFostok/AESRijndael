using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes192UnitTest
    {
        private const string INPUT = "00112233445566778899AABBCCDDEEFF";
        private const string OUTPUT = "DDA97CA4864CDFE06EAF70A0EC0D7191";
        private const string KEY = "000102030405060708090a0b0c0d0e0f1011121314151617";

        [TestMethod]
        public void Aes192_Encrypt_Success()
        {
            Encryptor encryptor = new();
            string outputByte = encryptor.Encrypt192(INPUT, KEY);
            Assert.AreEqual(OUTPUT, outputByte);
        }

        [TestMethod]
        public void Aes192_Decrypt_Success()
        {
            Decreptor encryptor = new();
            string outputByte = encryptor.Decrept192(OUTPUT, KEY);
            Assert.AreEqual(INPUT, outputByte);
        }
    }
}
