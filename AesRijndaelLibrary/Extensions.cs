using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary
{
    public static class Extensions
    {
        public const int NB = 4;
        private static Dictionary<char, byte> hexa = new Dictionary<char, byte> { { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'a', 10 }, { 'b', 11 }, { 'c', 12 }, { 'd', 13 }, { 'e', 14 }, { 'f', 15 } };
        private static Dictionary<byte, char> hexarevers;

        static Extensions()
        {
            hexarevers = hexa.ToDictionary(c => c.Value, c => c.Key);
        }

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

        public static byte GetByteFromHex(this string name)
        {
            //return name.Length switch
            //{
            //    1 => Convert.ToByte(hexa[name[0]]),
            //    2 => Convert.ToByte(hexa[name[0]] * 16 + hexa[name[1]]),
            //    _ => throw new ArgumentException("Length must be 1 or 2"),
            //};

            if (name.Length == 2)
            {
                return Convert.ToByte(hexa[name[0]] * 16 + hexa[name[1]]);
            }
            if (name.Length == 1)
            {
                return Convert.ToByte(hexa[name[0]]);
            }

            throw new ArgumentException("Length must be 1 or 2");
        }
    }
}