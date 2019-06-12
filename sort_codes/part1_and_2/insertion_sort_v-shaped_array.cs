using System;
using System.Diagnostics;

namespace sort
{
    class Program
    {
        public static void sort(int[] tab)
        {
            for (uint i = 1; i < tab.Length; i++)
            {
                uint j = i;
                int temp = tab[j];

                while ((j > 0) && (tab[j - 1] > temp))
                {
                    tab[j] = tab[j - 1];
                    j--;
                }

                tab[j] = temp;
            }
    }
        static int[] getVshaped(int[] n)
        {
            int count = 0;

            for (int i = n.Length / 2; i > 0; i--)
            {
                n[count++] = i;
            }

            for (int i = 0; i < n.Length / 2; i++)
            {
                n[count++] = i;
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
                getVshaped(table);
                
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
