using System;
using System.Collections.Generic;

namespace AesRijndaelLibrary
{
    public static class Extensions
    {
        public const int NB = 4;

        public static List<byte> ConvertKeyFromStringToByteArray(this string text)
        {
            List<byte> bytes = new();

            try
            {
                for (int index = 0; index < text.Length; index += 2)
                {
                    bytes.Add(text.Substring(index, 2).GetByteFromHex());
                }
                return bytes;
            }
            catch (ArgumentOutOfRangeException)
            {
                bytes.Add(text[^1].ToString().GetByteFromHex());
                return bytes;
            }
        }


        public static string GetHexadecimal(this byte value) =>
            BitConverter.ToString(new byte[] { value });

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
            if (hexByte.Length is not (1 or 2))
                throw new ArgumentException("Length must be 1 or 2");

            return Convert.ToByte(hexByte, 16);
        }
    }
}