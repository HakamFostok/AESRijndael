using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;

namespace AesRijndaelLibrary
{
    [Serializable]
    internal class Table
    {
        private List<List<byte>> dataInTable { get; set; }
        //private static BinaryFormatter<Table> tableFormatter;

        internal static Table SBox { get; private set; }
        internal static Table InverseSBox { get; private set; }
        internal static Table TableE { get; private set; }
        internal static Table TableL { get; private set; }
        private static Dictionary<char, byte> hexa = new Dictionary<char, byte>() { { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'a', 10 }, { 'b', 11 }, { 'c', 12 }, { 'd', 13 }, { 'e', 14 }, { 'f', 15 } };

        static Table()
        {
            //tableFormatter = new BinaryFormatter<Table>();

            //SBox = tableFormatter.DeserializeFromFileAndClose("STableBinary");
            //InverseSBox = tableFormatter.DeserializeFromFileAndClose("InversSTableBinary");
            //TableE = tableFormatter.DeserializeFromFileAndClose("ETableBinary");
            //TableL = tableFormatter.DeserializeFromFileAndClose("LTableBinary");

            SBox = new Table("SBox.txt");
            InverseSBox = new Table("InvSBox.txt");
            TableE = new Table("E.txt");
            TableL = new Table("L.txt");
        }

        private Table(string fileName)
        {
            dataInTable = File.ReadAllLines(fileName).
                Select(line => new List<byte>(line.Split(' ').
                    Select(word => Convert.ToByte(hexa[char.ToLower(word[0])] * 16 + hexa[char.ToLower(word[1])])))).ToList();
        }

        //public Table()
        //{
        //    dataInTable = new List<List<byte>>();
        //}

        internal byte this[int row, int column]
        {
            get
            {
                return dataInTable[row][column];
            }
        }
    }
}
