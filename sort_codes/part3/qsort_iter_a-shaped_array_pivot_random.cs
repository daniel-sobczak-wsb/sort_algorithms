using System;
using System.Diagnostics;

namespace sort
{
    class Program
    {
        public static void sort(int[] t)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int [t.Length],
                stos_p = new int [t.Length];
            sp = 0;
            stos_l[sp] = 0;
            stos_p[sp] = t.Length - 1;

            Random rnd_pivot = new Random(Guid.NewGuid().GetHashCode());

            do
            {
                l = stos_l[sp];
                p = stos_p[sp];
                sp--;

                do
                {
                    int x;
                    i = l;
                    j = p;
                    x = t[rnd_pivot.Next(i, j)];
                    
                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i];
                            t[i] = t[j];
                            t[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);

                    if (i < p)
                    {
                        sp++;
                        stos_l[sp] = i;
                        stos_p[sp] = p;
                    }
                    p = j;
                } while (l < p);
            } while (sp >= 0);
        }
        static int[] getAshaped(int[] n)
        {
            int count = 0;

            for (int i = 0; i < n.Length / 2; i++)
            {
                n[count++] = i;
            }

            for (int i = n.Length / 2; i > 0; i--)
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
                getAshaped(table);

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
