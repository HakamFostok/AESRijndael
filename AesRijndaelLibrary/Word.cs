using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary
{
    internal class Word : IEnumerable<byte>
    {
        private List<byte> bytes { get; set; }

        internal Word(byte b0, byte b1, byte b2, byte b3)
            : this(new List<byte>() { b0, b1, b2, b3 })
        {
        }

        internal Word(List<byte> fourBytes)
        {
            if (fourBytes.Count != 4)
                throw new ArgumentOutOfRangeException("fourBytes", "Length of fourBytes must be 4");
            
            bytes = new List<byte>();
            bytes.AddRange(fourBytes.Select(n => n));
        }

        internal byte this[int index]
        {
            get
            {
                ValidateIndex(index);
                return bytes[index];
            }
            set
            {
                ValidateIndex(index);
                bytes[index] = value;
            }
        }

        private static void ValidateIndex(int index)
        {
            if (index < 0 || index >= 4)
            {
                throw new ArgumentOutOfRangeException("index", "index must be 0, 1, 2 or 3");
            }
        }

        internal static Word Xor(Word w1, Word w2) =>
            new Word(w1.Select((b, index) => Convert.ToByte(b ^ w2[index])).ToList());

        internal Word RotWord() =>
            new Word(this[1], this[2], this[3], this[0]);

        internal Word SubWord() =>
            new Word(this.Select(b => Table.SBox[b.GetUpperPart(), b.GetLowerPart()]).ToList());
        
        #region IEnumerable
        IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
        {
            for (int index = 0; index < bytes.Count(); index++)
            {
                yield return bytes[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            throw new NotImplementedException();

        #endregion
    }
}