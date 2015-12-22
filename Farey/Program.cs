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
            Count = (uint)Numbers.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
