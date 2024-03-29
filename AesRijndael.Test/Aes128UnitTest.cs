using System.Linq;

using AesRijndaelLibrary;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AesRijndael.Test;

[TestClass]
public class Aes128UnitTest
{
    private const string INPUT = "00112233445566778899AABBCCDDEEFF";
    private const string OUTPUT = "69C4E0D86A7B0430D8CDB78070B4C55A";
    private const string KEY = "000102030405060708090A0B0C0D0E0F";

    [TestMethod]
    public void Aes128_Encrypt_Success()
    {
        Encryptor encryptor = new();
        string outputByte = encryptor.Encrypt128(INPUT, KEY);
        Assert.AreEqual(OUTPUT, outputByte);
    }

    [TestMethod]
    public void Aes128_Decrypt_Success()
    {
        Decreptor encryptor = new();
        string outputByte = encryptor.Decrept128(OUTPUT, KEY);
        Assert.AreEqual(INPUT, outputByte);
    }

    [TestMethod]
    public void Aes128_EncryptAndDecrept_Success()
    {
        Encryptor encryptor = new();
        Decreptor decreptor = new();
        string input = "00987ABCDEF1234";
        string encreptedOutput = encryptor.Encrypt128(input, KEY);
        string decreptedOutput = decreptor.Decrept128(encreptedOutput, KEY);

        Assert.AreEqual(input, new string(decreptedOutput.Take(input.Length).ToArray()));
    }
}
