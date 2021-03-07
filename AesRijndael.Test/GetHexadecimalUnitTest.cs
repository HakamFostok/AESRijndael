using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesRijndaelLibrary;
using System;

namespace AesRijndael.Test
{
    [TestClass]
    public class GetHexadecimalUnitTest
    {
        [TestMethod]
        public void GetByteFromHex_Bytes_Success()
        {
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                string theByteHexValue = BitConverter.ToString(new byte[] { i });
                
                var actual = Extensions.GetHexadecimal(i);
                
                Assert.AreEqual(theByteHexValue.ToLower(), actual.ToLower());
            }
        }

    }
}
