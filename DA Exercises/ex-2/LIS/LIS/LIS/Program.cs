using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());
            string[] input = Console.ReadLine().Split();

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = Convert.ToInt32(input[i]);
            }

            int[] dp = new int[n];
            int len = 0;

            for (int i = 0; i < n; i++)
            {
                int index = Array.BinarySearch(dp, 0, len, numbers[i]);
                if (index < 0)
                {
                    index = -index - 1;
                }
                dp[index] = numbers[i];

                if (index == len)
                {
                    len++;
                }
            }

            Console.WriteLine(len);
            Console.ReadLine();
        }
    }
}
