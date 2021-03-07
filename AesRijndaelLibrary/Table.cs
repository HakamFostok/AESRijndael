using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AesRijndaelLibrary
{
    [Serializable]
    internal class Table
    {
        private readonly List<List<byte>> dataInTable;
        private static readonly Dictionary<char, byte> hexa = new Dictionary<char, byte>() { { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'a', 10 }, { 'b', 11 }, { 'c', 12 }, { 'd', 13 }, { 'e', 14 }, { 'f', 15 } };

        internal static Table SBox { get; private set; }
        internal static Table InverseSBox { get; private set; }
        internal static Table TableE { get; private set; }
        internal static Table TableL { get; private set; }


        static Table()
        {
            SBox = new Table("files\\SBox.txt");
            InverseSBox = new Table("files\\InvSBox.txt");
            TableE = new Table("files\\E.txt");
            TableL = new Table("files\\L.txt");
        }

        private Table(string fileName)
        {
            dataInTable = File.ReadAllLines(fileName).
                Select(line => new List<byte>(line.Split(' ').
                    Select(word => Convert.ToByte(hexa[char.ToLower(word[0])] * 16 + hexa[char.ToLower(word[1])])))).ToList();
        }

        internal byte this[int row, int column] =>
            dataInTable[row][column];
        
    }
}
