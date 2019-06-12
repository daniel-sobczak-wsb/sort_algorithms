using System;
using System.Diagnostics;

namespace sort
{
    class Program
    {
        public static void sort(int[] tab, int left, int right)
        {
            int i, j, x;
            i = left;
            j = right;
            x = tab[(left + right) / 2];

            do
            {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j)
                {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) sort(tab, left, j);
            if (i < right) sort(tab, i, right);
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
                sort(table, 0, table.Length - 1);
                long stop = Stopwatch.GetTimestamp();

                elapsedTime = stop - start;
                elapsedSeconds = elapsedTime * (1.0 / Stopwatch.Frequency);
                System.Console.WriteLine("{0};{1:F8}", i, elapsedSeconds);
            }
            Console.ReadKey();
        }
    }
}
