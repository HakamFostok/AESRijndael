using System;
using System.Linq;

namespace AesRijndaelLibrary;

[CLSCompliant(true)]
public abstract class AesBase
{
    private readonly int NR;

    private static int NB => Extensions.NB;

    protected AesBase(int nr)
    {
        NR = nr;
    }

    /// <summary>
    /// Encryption with AES Rijndael Algorithm.
    /// </summary>
    /// <param name="input">The Orginal Bytes that will be Ecrypted.</param>
    /// <param name="key">The key that will be used in Encryption Algorithm.</param>
    /// <returns>Cipher Bytes after Encrypt the Original Bytes.</returns>
    public byte[] Encrypt(byte[] input, AesKeyBase key)
    {
        Word[] w = key.KeyExpansion();
        if ((4 * NB != input.Length) && (NB * (NR + 1) != key.Length))
        {
            throw new ArgumentException("Length of input array must be multiplied by 4");
        }

        byte[,] state = GetStateMatrixFromTheInputArray(input);

        AddRoundKey(state, w.Take(4).ToArray());

        for (int round = 1; round <= NR - 1; round++)
        {
            SubByte(state);
            ShiftRow(state);
            MixColumns(state);
            AddRoundKey(state, w.Skip(NB * round).Take(NB).ToArray());
        }

        SubByte(state);
        ShiftRow(state);
        AddRoundKey(state, w.Skip(NB * NR).ToArray());    // here we donot need to take after the skip because we  will take the all remainder in the array

        return GetOutputArrayFromTheStateMatrix(state);
    }

    /// <summary>
    /// Inverse Ecryption with AES Rijndael Algorithm.
    /// </summary>
    /// <param name="output">The Cipher Bytes that will be Decrypted.</param>
    /// <param name="key">The key that will be used in Decryption Algorithm.</param>
    /// <returns>Original Bytes after Decrypt the Cipher Bytes.</returns>
    public byte[] Decrypt(byte[] output, AesKeyBase key)
    {
        byte[,] state = GetStateMatrixFromTheInputArray(output);
        Word[] w = key.KeyExpansion();

        AddRoundKey(state, w.Skip(NB * NR).ToArray());

        for (int round = NR - 1; round >= 1; round--)
        {
            InvShiftByte(state);
            InvSubByte(state);
            AddRoundKey(state, w.Skip(round * NB).Take(NB).ToArray());
            InvMixColumns(state);
        }

        InvShiftByte(state);
        InvSubByte(state);
        AddRoundKey(state, w.Take(NB).ToArray());

        return GetOutputArrayFromTheStateMatrix(state);
    }

    // check this method because it word
    private static void AddRoundKey(byte[,] state, Word[] keyWord)
    {
        for (int row = 0; row < state.GetLength(0); row++)
        {
            for (int column = 0; column < state.GetLength(1); column++)
            {
                state[column, row] ^= keyWord[row][column];
            }
        }
    }

    private static byte[,] GetStateMatrixFromTheInputArray(byte[] input)
    {
        byte[,] state = new byte[4, NB];
        for (int index = 0; index < input.Length; index++)
        {
            state[index % 4, index / 4] = input[index];
        }

        return state;
    }

    // this method has to been checked if it is word correctly or not.
    private static byte[] GetOutputArrayFromTheStateMatrix(byte[,] state)
    {
        byte[] output = new byte[state.GetLength(0) * state.GetLength(1)];

        for (int row = 0; row < state.GetLength(0); row++)
        {
            for (int column = 0; column < state.GetLength(1); column++)
            {
                output[row * NB + column] = state[column, row];
            }
        }

        return output;
    }

    private static void MixColumns(byte[,] state) => GeneralMixColumns(state,
            new byte[4, 4] { { 2, 3, 1, 1 }, { 1, 2, 3, 1 }, { 1, 1, 2, 3 }, { 3, 1, 1, 2 } });

    private static void InvMixColumns(byte[,] state) => GeneralMixColumns(state,
            new byte[4, 4] { { 0xe, 0xb, 0xd, 0x9 }, { 0x9, 0xe, 0xb, 0xd }, { 0xd, 0x9, 0xe, 0xb }, { 0xb, 0xd, 0x9, 0xe } });

    private static void GeneralMixColumns(byte[,] state, byte[,] mul)
    {
        byte[] temp = new byte[4];
        byte[,] finalResult = new byte[state.GetLength(0), state.GetLength(1)];

        for (int col = 0; col < NB; col++)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int index = 0; index < 4; index++)
                {
                    temp[index] = ComplexOperation(state[index, col], mul[row, index]);
                }
                for (int index = 1; index < 4; index++)
                {
                    temp[0] ^= temp[index];
                }

                finalResult[row, col] = temp[0];
            }
        }

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < state.GetLength(1); col++)
            {
                state[row, col] = finalResult[row, col];
            }
        }
    }

    internal static byte ComplexOperation(byte b1, byte b2)
    {
        //return Convert.ToByte((int)BinaryPolynomial.ComplexOperation(b1, b2));

        if (b1 == 0 || b2 == 0)
        {
            return 0;
        }
        if (b1 == 1)
        {
            return b2;
        }
        if (b2 == 1)
        {
            return b1;
        }

        b1 = Table.TableL[b1.GetUpperPart(), b1.GetLowerPart()];
        b2 = Table.TableL[b2.GetUpperPart(), b2.GetLowerPart()];
        int resultOfSum = b1 + b2;

        if (resultOfSum > byte.MaxValue)
        {
            resultOfSum -= byte.MaxValue;
        }

        byte resultByByte = Convert.ToByte(resultOfSum);
        return Table.TableE[resultByByte.GetUpperPart(), resultByByte.GetLowerPart()];
    }

    private static void InvShiftByte(byte[,] state) => GeneralShift(state, false);

    private static void ShiftRow(byte[,] state) => GeneralShift(state, true);

    private static void GeneralShift(byte[,] state, bool encrypt)
    {
        for (int row = 1; row < state.GetLength(0); row++)
        {
            byte[] temp = new byte[NB];
            for (int index = 0; index < temp.Length; index++)
            {
                // the formula of the rotate to left by n times is
                // newIndex = oldIndex + ( LengthOfByte - n ) % LengthOfByte
                int shiftValue = (encrypt) ? row : NB - row;
                temp[(index + NB - shiftValue) % NB] = state[row, index];
            }
            for (int index = 0; index < temp.Length; index++)
            {
                state[row, index] = temp[index];
            }
        }
    }

    private static void InvSubByte(byte[,] state) => GeneralSubByte(state, b => Table.InverseSBox[b.GetUpperPart(), b.GetLowerPart()]);

    private static void SubByte(byte[,] state) => GeneralSubByte(state, b => Table.SBox[b.GetUpperPart(), b.GetLowerPart()]);

    private static void GeneralSubByte(byte[,] state, Func<byte, byte> ff)
    {
        for (int row = 0; row < state.GetLength(0); row++)
        {
            for (int column = 0; column < state.GetLength(1); column++)
            {
                state[row, column] = ff(state[row, column]);
            }   // end inner for
        }   // end outer for
    }   // end method

}   // end class
