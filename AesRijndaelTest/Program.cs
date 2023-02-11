using System;
using System.Linq;

using AesRijndaelLibrary;

namespace AesRijndaelTest;

internal class Program
{
    private static BinaryFormatter<Table> formatter = new BinaryFormatter<Table>();

    private static readonly byte[] input = new byte[]
    {
            0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff
    };

    static void Main(string[] args)
    {
        // this code the produce the binary file for the first time.

        //formatter.SerializeToFileAndClose("STableBinary", Table.SBox);
        //formatter.SerializeToFileAndClose("InversSTableBinary", Table.InverseSBox);
        //formatter.SerializeToFileAndClose("ETableBinary", Table.TableE);
        //formatter.SerializeToFileAndClose("LTableBinary", Table.TableL);

        // TestMyFunction();

        //Test Aes128
        byte[] key128 = new byte[]
        {
               0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f
        };
        TestAesBase(new Aes128(), new AesKey128(key128), "128", new byte[] { 0x69, 0xc4, 0xe0, 0xd8, 0x6a, 0x7b, 0x04, 0x30, 0xd8, 0xcd, 0xb7, 0x80, 0x70, 0xb4, 0xc5, 0x5a });

        // Test Aes192
        byte[] key192 = new byte[]
        {
               0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10,0x11 ,0x12 ,0x13 ,0x14 ,0x15 ,0x16 ,0x17
        };
        TestAesBase(new Aes192(), new AesKey192(key192), "192", new byte[] { 0xdd, 0xa9, 0x7c, 0xa4, 0x86, 0x4c, 0xdf, 0xe0, 0x6e, 0xaf, 0x70, 0xa0, 0xec, 0x0d, 0x71, 0x91 });

        // Test Aes256
        byte[] key256 = new byte[]
        {
                 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10,0x11 ,0x12 ,0x13 ,0x14 ,0x15 ,0x16 ,0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f
        };
        TestAesBase(new Aes256(), new AesKey256(key256), "256", new byte[] { 0x8e, 0xa2, 0xb7, 0xca, 0x51, 0x67, 0x45, 0xbf, 0xea, 0xfc, 0x49, 0x90, 0x4b, 0x49, 0x60, 0x89 });
    }

    private static void TestMyFunction()
    {
        int counter = 0;

        for (byte i = 0; i < 16; i++)
        {
            for (byte j = 0; j < 16; j++)
            {
                if ((Aes128.ComplexOperation(j, i)) != ((int)BinaryPolynomial.ComplexOperation(j, i)))
                {
                    counter++;
                }
            }
        }

        Console.WriteLine(counter);
    }

    private static void TestAesBase(AesBase algo, AesKeyBase aeskey, string name, byte[] forCheck)
    {
        // Test the Example in the book.
        byte[] output = algo.Encrypt(input, aeskey);
        byte[] inputRevers = algo.Decrypt(output, aeskey);
        if (output.SequenceEqual(forCheck))
        {
            Console.WriteLine("The aes" + name + " example is right");
        }
        else
        {
            Console.WriteLine("The aes " + name + " example is wrong");
        }
        //if (input.SequenceEqual(inputRevers))
        //{
        //    Console.WriteLine("The example is right with the Algorithm Aes" + name);
        //}
        //else
        //{
        //    Console.WriteLine("The example is worng with the algorithm Aes" + name);
        //}

        // Test So many Input
        //List<int> errors = new List<int>();

        //Console.WriteLine("Testing Algorithm Aes " + name + " .Please Wait...");
        //for (int time = 0; time < input.Length; time++)
        //{
        //    for (int i = 0; i <= 9; i++)
        //    {
        //        input[time] = Convert.ToByte(i);
        //        output = algo.Encrypt(input, aeskey);
        //        byte[] check = algo.Decrypt(output, aeskey);

        //        if (!input.SequenceEqual(check))
        //        {
        //            errors.Add(time);
        //        }
        //    }
        //}

        //Console.Write("Testing Algorithm Aes" + name + " Finished.\nThe Results is :");
        //if (errors.Count > 0)
        //{
        //    Console.WriteLine("There is error in\n");
        //    for (int index = 0; index < errors.Count; index++)
        //    {
        //        Console.WriteLine(index + " ");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Every thing all right\n");
        //}
    }
}
