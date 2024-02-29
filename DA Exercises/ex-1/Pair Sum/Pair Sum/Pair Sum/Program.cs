using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pair_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] strArray = Console.ReadLine().Split();

            int[] array = new int[n];

            for(int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(strArray[i]);
            }
            
            int target = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(targetNumber(n, array, target));
            Console.ReadLine();

        }

        public static int targetNumber(int n , int[] array, int target)
        {
            Dictionary <int , int> dp = new Dictionary<int , int>();

            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                if(dp.ContainsKey(target - array[i]))
                {
                    counter += dp[target - array[i]];
                }

                else if (dp.ContainsKey(array[i])) 
                {
                    dp[array[i]]++;
                }

                else
                {
                    dp[array[i]] = 1;
                }
            }

            return counter * 2;


        }
    }
}
