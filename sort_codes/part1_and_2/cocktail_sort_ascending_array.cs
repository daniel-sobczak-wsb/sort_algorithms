using System;
using System.Diagnostics;

namespace sort
{
    class Program
    {
        public static void sort(int[] tab)
        {
            int left = 1, right = tab.Length - 1, k = tab.Length - 1;
            do
            {
                for (int j = right; j >= left; j--)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                left = k + 1;

                for (int j = left; j <= right; j++)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                right = k - 1;
            } while
                (left <= right);
        }
        static int[] getAscending(int[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = i+1;
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
                getAscending(table);

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
