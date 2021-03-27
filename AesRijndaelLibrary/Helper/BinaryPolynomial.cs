using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AesRijndaelLibrary
{
    class BinaryPolynomial : IEnumerable<int>
    {
        private SortedSet<int> values { get; set; }

        public BinaryPolynomial()
        {
            values = new SortedSet<int>();
        }

        public BinaryPolynomial(int number)
            : this()
        {
            BitArray temp = new BitArray(new int[] { number });

            for (int index = 0; index < temp.Count; index++)
            {
                if (temp[index])
                {
                    values.Add(index);
                }
            }
        }

        public bool this[int index]
        {
            get
            {
                return values.Contains(index);
            }
            set
            {
                if (value)
                {
                    values.Add(index);
                }
                else
                {
                    if (values.Contains(index))
                    {
                        values.Remove(index);
                    }
                }
            }
        }

        public static BinaryPolynomial Xor(BinaryPolynomial left, BinaryPolynomial right)
        {
            return new BinaryPolynomial
            {
                values =
                    new SortedSet<int>(left.Concat(right).Except(left.Intersect(right)).Distinct())
            };
        }

        public static BinaryPolynomial ComplexOperation(int first, int second)
        {
            if (first == 0 || second == 0)
                return new BinaryPolynomial(0);

            if (first == 1)
                return new BinaryPolynomial(second);

            if (second == 1)
                return new BinaryPolynomial(first);

            var result = Multiply(new BinaryPolynomial(first), new BinaryPolynomial(second));
            return ReminderConstant(result);
        }

        public static BinaryPolynomial Reminder(BinaryPolynomial up, BinaryPolynomial down)
        {
            BinaryPolynomial result = new BinaryPolynomial { values = new SortedSet<int>(up.Select(num => num)) };

            while (result.Last() >= down.Last())
            {
                result = Xor(result, MultiplyByNumber(down, result.Last() - down.Last()));
            }

            return result;
        }

        private static BinaryPolynomial ReminderConstant(BinaryPolynomial up)
        {
            return Reminder(up, new BinaryPolynomial(283));
        }

        public static BinaryPolynomial Multiply(BinaryPolynomial left, BinaryPolynomial righ)
        {
            return left.Select(item => BinaryPolynomial.MultiplyByNumber(righ, item)).Aggregate((first, second) => BinaryPolynomial.Xor(first, second));
        }

        public static BinaryPolynomial MultiplyByNumber(BinaryPolynomial left, int number)
        {
            return new BinaryPolynomial { values = new SortedSet<int>(left.Select(num => num + number)) };
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            foreach (int item in values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            throw new NotImplementedException();

        public static explicit operator int(BinaryPolynomial left)
        {
            int result = 0;
            foreach (int item in left)
            {
                result += Convert.ToInt32(Math.Pow(2, item));
            }
            return result;
        }
    }
}