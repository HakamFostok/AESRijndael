using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;

namespace AesRijndael.Test
{
    [TestClass]
    public class Aes192UnitTest
    {
        [TestMethod]
        public void Aes192_Encrypt_Success()
        {
            Encryptor encryptor = new();
            var outputByte = encryptor.Encrypt192("00112233445566778899aabbccddeeff",
                "000102030405060708090a0b0c0d0e0f1011121314151617");

            string expectedOutput = "DDA97CA4864CDFE06EAF70A0EC0D7191";
            Assert.AreEqual(expectedOutput, outputByte);
        }

        [TestMethod]
        public void Aes192_Decrypt_Success()
        {
            Decreptor encryptor = new();
            var outputByte = encryptor.Decrept192("DDA97CA4864CDFE06EAF70A0EC0D7191",
                "000102030405060708090a0b0c0d0e0f1011121314151617");

            string expectedOutput = "00112233445566778899AABBCCDDEEFF";
            Assert.AreEqual(expectedOutput, outputByte);
        }
    }
}
