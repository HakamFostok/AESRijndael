using System;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary;

[CLSCompliant(true)]
public abstract class AesKeyBase : IEnumerable<byte>
{
    internal static Dictionary<int, int> dic { get; set; }
    internal int NK { get; private set; }
    public List<byte> Subkeys { get; set; }

    public int NR => dic[NK];

    static AesKeyBase()
    {
        dic = new Dictionary<int, int> { { 4, 10 }, { 6, 12 }, { 8, 14 } };
    }

    protected AesKeyBase(int keyLength)
    {
        if (keyLength is not (4 or 6 or 8))
            throw new ArgumentOutOfRangeException(nameof(keyLength), "KeyLength is not 4, 6 or 8");

        NK = keyLength;
    }

    protected AesKeyBase(int keyLength, string key)
         : this(keyLength)
    {
        Subkeys = key.ConvertKeyFromStringToByteArray().ToList();
    }

    protected AesKeyBase(int keyLength, byte[] key)
        : this(keyLength)
    {
        Subkeys = key.ToList();
    }

    public int Length => NK;

    public IEnumerator<byte> GetEnumerator()
    {
        for (int index = 0; index < Length; index++)
        {
            yield return Subkeys[index];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw new NotImplementedException();

    internal Word[] KeyExpansion()
    {
        List<Word> words = new();

        int i = 0;
        for (i = 0; i < NK; i++)
            words.Add(new Word(Subkeys[i * 4], Subkeys[i * 4 + 1], Subkeys[i * 4 + 2], Subkeys[i * 4 + 3]));

        // already i = Nk;
        for (; i < Extensions.NB * (NR + 1); i++)
        {
            Word temp = words[i - 1];

            if (i % NK == 0)
                temp = Word.Xor((temp.RotWord()).SubWord(), Rcon(i / NK));
            else if (NK > 6 && i % NK == 4)
                temp = temp.SubWord();

            Word word = Word.Xor(words[i - NK], temp);
            words.Add(word);
        }

        return words.ToArray<Word>();
    }

    private static Word Rcon(int i)
    {
        int temp = 1;
        for (int index = 0; index < i - 1; index++)
        {
            temp <<= 1;
            if (temp > byte.MaxValue)
            {
                temp &= byte.MaxValue;
                temp ^= 27;
            }
        }

        return new Word(Convert.ToByte(temp), 0, 0, 0);
    }
}
