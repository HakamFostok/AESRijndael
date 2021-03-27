using System;

using AesRijndaelLibrary;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AesRijndael.Test
{
    [TestClass]
    public class GetByteFromHexUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetByteFromHex_NoChar_Fail()
        {
            Extensions.GetByteFromHex("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetByteFromHex_3Char_Fail()
        {
            Extensions.GetByteFromHex("123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetByteFromHex_4Char_Fail()
        {
            Extensions.GetByteFromHex("1234");
        }

        [TestMethod]
        public void GetByteFromHex_Bytes_Success()
        {
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                string theByteHexValue = BitConverter.ToString(new byte[] { i });

                var actual1 = Extensions.GetByteFromHex(theByteHexValue);
                var actual2 = Extensions.GetByteFromHex(theByteHexValue.ToLower());

                Assert.AreEqual(i, actual1);
                Assert.AreEqual(i, actual2);
            }
        }


        [TestMethod]
        public void GetByteFromHex_SingleCharBytes_Success()
        {
            for (byte i = 0; i < 10; i++)
            {
                var actual = Extensions.GetByteFromHex(i.ToString());
                Assert.AreEqual(i, actual);
            }
        }

    }
}
