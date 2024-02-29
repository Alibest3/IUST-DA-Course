using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);
            int k = Convert.ToInt32(input[2]);

            
            string[] strArr1 = Console.ReadLine().Split();
            string[] strArr2 = Console.ReadLine().Split();
            string[] strArr3 = Console.ReadLine().Split();

            int[] arr1 = new int[n];
            int[] arr2 = new int[m];
            int[] arr3 = new int[k];

            for (int i = 0; i<n; i++)
            {
                arr1[i] = Convert.ToInt32(strArr1[i]);
            }

            for (int i = 0; i<m; i++)
            {
                arr2[i] = Convert.ToInt32(strArr2[i]);
            }
            
            for (int i = 0;i<k; i++)
            {
                arr3[i] = Convert.ToInt32(strArr3[i]);
            }

            int[,,] dp = new int[n + 1, m + 1, k + 1];

            
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    for (int l = 1; l <= k; l++)
                    {
                        if (arr1[i - 1] == arr2[j - 1] && arr2[j - 1] == arr3[l - 1])
                        {
                            dp[i, j, l] = dp[i - 1, j - 1, l - 1] + 1;
                        }
                        else
                        {
                            dp[i, j, l] = Math.Max(Math.Max(dp[i - 1, j, l], dp[i, j - 1, l]), dp[i, j, l - 1]);
                        }
                    }
                }
            }

            Console.WriteLine(dp[n, m, k]);
            Console.ReadLine();
        }
    }
}
