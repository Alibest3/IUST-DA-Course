using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Coin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int n = Convert.ToInt32(input[0]);
            int v = Convert.ToInt32(input[1]);

            string[] array = Console.ReadLine().Split();

            int[] coins = new int[n];

            for (int i = 0; i< n; i++)
            {
                coins[i] = Convert.ToInt32(array[i]);
            }


            Console.WriteLine(MinimumCoins(coins, n, v));
            Console.ReadLine();
            
        }

        public static int MinimumCoins(int[] coins, int n, int v)
        {
            int[,] array = new int[v + 1, n + 1];
            for (int i = 0; i<= v;i++)
            {
                array[i, 0] = int.MaxValue - 1;
            }

            for (int j = 0; j<= n; j++)
            {
                array[0, j] = 0;
            }

            for (int j = 1; j<= n; j++)
            {
                for (int i = 1; i<= v; i++)
                {
                    if (coins[j -1] > i)
                    {
                        array[i, j] = array[i, j - 1];
                    }
                    else
                    {
                        array[i,j] = Math.Min(array[i,j - 1], array[i - coins[j-1],j] + 1);
                    }
                }
            }
            if (array[v,n] == int.MaxValue - 1)
            {
                return -1;
            }
            return array[v,n];
        }
    }
}
