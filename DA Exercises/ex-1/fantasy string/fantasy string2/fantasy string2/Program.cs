using System;
using System.Linq;

namespace fantasy_string2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.WriteLine(fantasyString(str));
            Console.ReadLine();

        }

        public static int fantasyString(string str)
        {
            int[] dp = new int[str.Length + 1];

            int a = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsUpper(str[i]))
                {
                    a++;
                }
            }
            dp[0] = a;
            if (dp[0] == 0)
            {
                return dp[0];
            }
            for (int i = 1; i <= str.Length; i++)
            {
                if (Char.IsUpper(str[i-1]))
                {
                    dp[i] = dp[i - 1] - 1;
                }

                else
                {
                    dp[i] = dp[i - 1] + 1;
                }
                

            }
            return dp.Min();

        }
    }
}
