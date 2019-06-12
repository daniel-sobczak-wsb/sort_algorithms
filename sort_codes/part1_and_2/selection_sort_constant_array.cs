using System;
using System.Diagnostics;

namespace sort
{
    class Program
    {
        public static void sort(int[] tab)
        {
            uint k;
            for (uint i = 0; i < (tab.Length - 1); i++)
            {
                int temp = tab[i];
                k = i;
                for (uint j = i + 1; j < tab.Length; j++)
                    if (tab[j] < temp)
                    {
                        k = j;
                        temp = tab[j];
                    }

                tab[k] = tab[i];
                tab[i] = temp;
            }
        }
        static int[] getConst(int[] n)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int random = rnd.Next(1, n.Length);

            for (int i = 0; i < n.Length; i++)
            {
                n[i] = random;
            }
            return n;
        }
        static void Main(string[] args)
        {
            double elapsedSeconds = 0;
            double elapsedTime = 0;
            System.Console.WriteLine("k;elapsed_seconds");
            for (int i = 50000; i <= 200000; i += 10000)
            {
                int[] table = new int[i];
                getConst(table);

                long start = Stopwatch.GetTimestamp();
                sort(table);
                long stop = Stopwatch.GetTimestamp();

                elapsedTime = stop - start;
                elapsedSeconds = elapsedTime * (1.0 / Stopwatch.Frequency);
                System.Console.WriteLine("{0};{1:F8}", i, elapsedSeconds);
            }
            Console.ReadKey();
        }
    }
}
