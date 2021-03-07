using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary
{
    public static class Extensions
    {
        public const int NB = 4;
        private static Dictionary<byte, char> hexarevers;

        public static string GetHexadecimal(this byte value)
        {
            byte lower = value.GetLowerPart();
            byte higher = value.GetUpperPart();
            return hexarevers[higher].ToString() + hexarevers[lower].ToString();
        }

        public static byte GetLowerPart(this byte value) =>
            Convert.ToByte(value & 15);

        public static byte GetUpperPart(this byte value)
        {
            value &= 240;
            value >>= 4;
            return value;
        }

        public static byte GetByteFromHex(this string hexByte)
        {
            if (hexByte.Length is not 1 or 2)
                throw new ArgumentException("Length must be 1 or 2");

            return Convert.ToByte(hexByte, 16);
        }
    }
}