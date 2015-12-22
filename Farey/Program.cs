using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farey
{
    public class FareyNumber
    {
        public readonly uint N;
        public readonly uint D;

        public FareyNumber(uint n, uint d)
        {
            N = n;
            D = d;
        }

        public override string ToString()
        {
            string result = String.Format("{0}/{1}", N, D);
            return result;
        }
    }

    public class FareyNumbers
    {
        public readonly uint Num;
        public readonly uint Count;

        public readonly HashSet<FareyNumber> Numbers = new HashSet<FareyNumber>();

        public FareyNumbers(uint N)
        {
            Num = N;
            generateNumbers();
            Count = (uint)Numbers.Count;
        }
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            HashSet<FareyNumber>.Enumerator it = Numbers.GetEnumerator();
            while(it.MoveNext())
            {
                if(buffer.Length > 0)
                    buffer.Append(',');
                buffer.Append(it.Current.ToString());
            }

            return buffer.ToString();
        }

        private void generateNumbers()
        {
            if(Num == 1)
            {
                Numbers.Add(new FareyNumber(0, 1));
                Numbers.Add(new FareyNumber(1, 1));
            }
            if (Num == 2)
            {
                Numbers.Add(new FareyNumber(0, 1));
                Numbers.Add(new FareyNumber(1, 2));
                Numbers.Add(new FareyNumber(1, 1));
            }
            if (Num == 3)
            {
                Numbers.Add(new FareyNumber(0, 1));
                Numbers.Add(new FareyNumber(1, 3));
                Numbers.Add(new FareyNumber(1, 2));
                Numbers.Add(new FareyNumber(2, 3));
                Numbers.Add(new FareyNumber(1, 1));
            }
            if (Num == 4)
            {
                Numbers.Add(new FareyNumber(0, 1));
                Numbers.Add(new FareyNumber(1, 4));
                Numbers.Add(new FareyNumber(1, 3));
                Numbers.Add(new FareyNumber(1, 2));
                Numbers.Add(new FareyNumber(2, 3));
                Numbers.Add(new FareyNumber(3, 4));
                Numbers.Add(new FareyNumber(1, 1));
            }
            if (Num == 5)
            {
                Numbers.Add(new FareyNumber(0, 1));
                Numbers.Add(new FareyNumber(1, 5));
                Numbers.Add(new FareyNumber(1, 4));
                Numbers.Add(new FareyNumber(1, 3));
                Numbers.Add(new FareyNumber(2, 5));
                Numbers.Add(new FareyNumber(1, 2));
                Numbers.Add(new FareyNumber(3, 5));
                Numbers.Add(new FareyNumber(2, 3));
                Numbers.Add(new FareyNumber(3, 4));
                Numbers.Add(new FareyNumber(4, 5));
                Numbers.Add(new FareyNumber(1, 1));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FareyNumbers nums = new FareyNumbers(2);
            Console.WriteLine(nums.ToString());

        }
    }
}
