using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            int n = Convert.ToInt32(input1[0]);
            int b = Convert.ToInt32(input1[1]);

            string[] input2 = Console.ReadLine().Split();
            int[] array = new int[n];

            for(int i = 0; i < n;i++)
            {
                array[i] = Convert.ToInt32(input2[i]);
            }

            int[,,] dp = new int[3, n + 1, b + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= b; j++)
                {
                    dp[1, i, j] = int.MaxValue;
                    dp[2, i, j] = int.MaxValue;
                }
            }
            dp[1, 0, 0] = 0;
            dp[2, 0, 0] = 0;

            // Fill dp array
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    // If person i goes to room 1
                    for (int k = 0; k < i; k++)
                    {
                        if (j <= b && j > 0)
                        {
                            dp[1, i, j] = Math.Min(dp[1, i, j], dp[2, k, j - 1] + (array[i - 1] == array[k] ? 0 : array[k]));
                        }
                    }
                    // If person i goes to room 2
                    for (int k = 0; k < i; k++)
                    {
                        if (j <= b && j > 0)
                        {
                            dp[2, i, j ] = Math.Min(dp[2, i, j], dp[1, k, j - 1] + (array[i - 1] == array[k] ? 0 : array[k]));
                        }
                    }
                }
            }

            // Find minimum cost
            int minCost = int.MaxValue;
            for (int j = 1; j <= b; j++)
            {
                minCost = Math.Min(minCost, Math.Min(dp[1, n, j], dp[2, n, j]));
            }
            Console.WriteLine(minCost);

            Console.ReadLine();
        }
    }
}
