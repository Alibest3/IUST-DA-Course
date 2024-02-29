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
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');
            int lenArr1 = arr1.Length;
            int lenArr2 = arr2.Length;
            int[,] dp = new int[lenArr1+1,lenArr2+1];
            for (int i = 0; i < lenArr1+1; i++)
            {

                for (int j = 0; j < lenArr2 +1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (arr1[i-1] == arr2[j-1])
                    {
                        dp[i,j] = dp[i-1,j-1]+1;
                    }
                    else
                    {
                        dp[i,j] = Math.Max(dp[i - 1, j], dp[i,j-1]);
                    }
                }
            }
            Console.WriteLine(dp[lenArr1,lenArr2]);
            Console.ReadLine();
        }
    }
}
