using System;

namespace Kesh_Ziad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);

            if (n <= 0 || m < 0)
            {
                Console.WriteLine(-1);
                Console.ReadLine();
            }


            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[,] dp = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    dp[i, j] = int.MaxValue / 4; 
                }
            }

            if (n == 1)
            {
                int p = (int)Math.Sqrt(m);
                if (p * p == m)
                {
                    Console.WriteLine((array[0] - p) * (array[0] - p));
                    Console.ReadLine();
                }
                else
                {   
                    Console.WriteLine(-1);
                    Console.ReadLine();
                }
            }

            for (int j = 0; j <= m; j++)
            {
                int p = (int)Math.Sqrt(j);
                if (p * p == j)
                {
                   dp[0, j] = Math.Min(dp[0, j], (array[0] - p) * (array[0] - p));
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    for (int k = 0; k <= j; k++)
                    {
                        int p = (int)Math.Sqrt(k);

                        if (p * p == k)
                        {
                            dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - k] + (array[i] - p) * (array[i] - p));
                        }
                    }
                }
            }

            if (dp[n - 1, m] == int.MaxValue / 4)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(dp[n - 1, m]);
            }
                Console.ReadLine();
        }
    }
}
