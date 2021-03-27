using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;
using System;

namespace AesRijndael.Test
{
    [TestClass]
    public class AesKeyUnitTest
    {
        public class WrongKey : AesKeyBase
        {
            public WrongKey()
                : base(5)
            {
            }
        }

        [TestMethod]
        public void Aes128_Key_Success()
        {
            new AesKey128();
            new AesKey128("1234");
        }

        [TestMethod]
        public void Aes192_Key_Success()
        {
            new AesKey192();
            new AesKey192("1234");
        }

        [TestMethod]
        public void Aes256_Key_Success()
        {
            new AesKey256();
            new AesKey256("1234");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Aes_WrongKey_Fail()
        {
            new WrongKey();
        }
    }
}
