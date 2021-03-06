﻿using System;
using System.Diagnostics;
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
        internal class FareyComparer : IComparer<FareyNumber>
        {
            public int Compare(FareyNumber a, FareyNumber b)
            {
                FareyNumber fn1 = (FareyNumber)a;
                FareyNumber fn2 = (FareyNumber)b;

                long tmp = 1;
                tmp = tmp * fn1.N * fn2.D - tmp * fn1.D * fn2.N;
                if (tmp > 0)
                    return 1;
                if (tmp < 0)
                    return -1;
                else
                    return 0;
            }
        }

        public readonly uint Num;
        public readonly uint Count;

        public readonly SortedSet<FareyNumber> Numbers = new SortedSet<FareyNumber>(new FareyComparer());

        public FareyNumbers(uint N)
        {
            Num = N;
            generateNumbers();
            Count = (uint)Numbers.Count;
        }
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            SortedSet<FareyNumber>.Enumerator it = Numbers.GetEnumerator();
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
            Numbers.Add(new FareyNumber(0, 1));
            Numbers.Add(new FareyNumber(1, 1));

            for (uint i = 1; i <= Num; i++)
            {
                for (uint j = i+1; j <= Num; j++)
                {
                    if(!canBeDivided(i,j))
                        Numbers.Add(new FareyNumber(i, j));
                }
            }
        }

        public static bool optimize
        {
            get;
            set;
        }

        private bool canBeDivided(uint A, uint B)
        {
            if(!optimize)
                return false;

            uint div = 2;
            Debug.Assert(A <= B);

            if (A == 1)
                return false;

            SortedSet<uint>.Enumerator it = primeNums.GetEnumerator();
            bool isPrime = true;
            while (it.MoveNext())
            {
                if (A % it.Current == 0)
                {
                    isPrime = false;
                    if (B % it.Current == 0)
                        return true;
                }
            }

            if(isPrime)
            {
                primeNums.Add(A);
            }

            return false;
        }

        private SortedSet<uint> primeNums = new SortedSet<uint>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            FareyNumbers nums = new FareyNumbers(3);
            Console.WriteLine(nums.ToString());

            FareyNumbers.optimize = true;
            DateTime start = DateTime.Now;
            FareyNumbers bigNum = new FareyNumbers(3000);
            DateTime end = DateTime.Now;

            TimeSpan duration = end - start;
            int mseconds = duration.Milliseconds;
            Console.WriteLine(mseconds);

            FareyNumbers.optimize = false;
            DateTime start2 = DateTime.Now;
            FareyNumbers bigNum2 = new FareyNumbers(3000);
            DateTime end2 = DateTime.Now;

            TimeSpan duration2 = end2 - start2;
            int mseconds2 = duration2.Milliseconds;
            Console.WriteLine(mseconds2);

        }
    }
}
