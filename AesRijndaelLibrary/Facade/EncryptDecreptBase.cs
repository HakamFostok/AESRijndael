using System.Collections.Generic;
using System.Linq;
using System;

namespace AesRijndaelLibrary
{

    [Obsolete("Consider making those method as extension methods and remove this class")]
    public abstract class EncryptDecreptBase
    {
        protected static List<string> PartitionTheTextTo32Chunck(string textOfInput)
        {
            List<string> totalInput = new();
            if (textOfInput.Length % 32 != 0)
                textOfInput += new string(Enumerable.Repeat<char>('0', 32 - (textOfInput.Length % 32)).ToArray());

            for (int index = 0; index < textOfInput.Length / 32; index++)
                totalInput.Add(new string(textOfInput.Skip(32 * index).Take(32).ToArray()));

            return totalInput;
        }

        protected static byte[] HandleTheInput(List<string> list)
        {
            string text = list.Select(line => new string(line.Where(ch => !char.IsWhiteSpace(ch)).ToArray())).Aggregate((one, two) => one + two);
            List<byte> bytesOfText = text.ConvertKeyFromStringToByteArray();

            // make the length of the bytes array multiplied by 16.
            while ((bytesOfText.Count % 16) != 0)
                bytesOfText.Add(0);

            return bytesOfText.ToArray();
        }

        protected static byte[] GetTheByteArrayOfTheKey(string key)
        {
            return key.ConvertKeyFromStringToByteArray().ToArray();
        }
    }
}