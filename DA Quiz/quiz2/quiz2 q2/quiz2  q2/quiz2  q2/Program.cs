using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2__q2
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            int[,] dp = new int[n + 1, k + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 0;
                dp[i, 1] = i;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 2; j <= k; j++)
                {
                    dp[i, j] = int.MaxValue;

                    int low = 1;
                    int high = i;
                    while (low <= high)
                    {
                        int mid = (low + high) / 2;

                        int tossesLeft = Math.Max(dp[mid - 1, j - 1], dp[i - mid, j]);

                        dp[i, j] = Math.Min(dp[i, j], tossesLeft + 1);

                        if (dp[mid - 1, j - 1] < dp[i - mid, j])
                        {
                            low = mid + 1;
                        }
                        else
                        {
                            high = mid - 1;
                        }
                    }
                }
            }
            Console.WriteLine(dp[n,k]);
            Console.ReadLine();
        }
    }
}
