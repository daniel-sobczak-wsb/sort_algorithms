using System;
using System.Diagnostics;

namespace sort
{
    class Program
    {
        public static void heapify(int[] t, uint left, uint right)
        {
            uint i = left, j = 2 * i + 1;
            int buf = t[i];

            while (j <= right)
            {
                if (j < right)
                    if (t[j] < t[j + 1])
                        j++;
                if (buf >= t[j]) break;

                t[i] = t[j];
                i = j;
                j = 2 * i + 1;
            }

            t[i] = buf;
        }

        public static void sort(int[] tab)
        {
            uint left = (uint) tab.Length / 2;
            uint right = (uint) tab.Length - 1;
            while (left > 0)
            {
                left--;
                heapify(tab, left, right);
            }

            while (right > 0)
            {
                int buf = tab[left];
                tab[left] = tab[right];
                tab[right] = buf;
                right--;
                heapify(tab, left, right);
            }
        }
        public static int[] getRandom(int n)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int[] tab = new int[n];
            

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = rnd.Next(1, 100000);
            }
            return tab;
        }
        static void Main(string[] args)
        {
            double elapsedSeconds = 0;
            double elapsedTime = 0;
            System.Console.WriteLine("k;elapsed_seconds");
            for (int i = 50000; i <= 200000; i += 10000)
            {
                int[] table = getRandom(i);
                
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
