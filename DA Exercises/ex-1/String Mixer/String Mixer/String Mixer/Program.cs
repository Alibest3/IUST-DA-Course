using System;

namespace String_Mixer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            string finalStr = Console.ReadLine();

            int n1 = str1.Length;
            int n2 = str2.Length;

            Console.WriteLine(isMix(str1, str2, finalStr, n1, n2));

            Console.ReadLine();

            

        }
        public static bool isMix(string str1,string str2,string finalStr, int n1,int n2)
        {
            if (finalStr.Length != n1 + n2)
            {
                return false;
            }

            if (finalStr.Length == 0)
            {
                return true;
            }


            bool[,] dp = new bool[n1 + 1, n2 + 1];

            for (int i = 0; i <= n1; i++)
            {
                for (int j = 0; j <= n2; j++)
                {
                    dp[i, j] = false;
                }
            }

            for (int i = 0; i <= n1; i++)
            {
                for (int j = 0; j <= n2; j++)
                {

                    if (i == 0 && j == 0)
                    {
                        dp[i,j] = true;
                    }

                    else if (i == 0)
                    {
                        if (str2[j - 1] == finalStr[j - 1])
                        {
                            dp[i, j] = dp[i, j - 1];
                        }
                    }

                    else if (j == 0)
                    {
                        if (str1[i - 1] == finalStr[i - 1])
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }

                    else if (str1[i - 1] == finalStr[i + j - 1] && str2[j - 1] != finalStr[i + j - 1])
                    {
                        dp[i,j] = dp[i - 1, j];
                    }
                    else if (str1[i - 1] != finalStr[i + j - 1] && str2[j - 1] == finalStr[i + j - 1])
                    {
                        dp[i, j] = dp[i, j - 1];
                    }

                    else if (str2[j - 1] == finalStr[i + j - 1] && str1[i - 1] == finalStr[i + j - 1])
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                    }

                    //dp[i, j] = first || second || third;
                }
            }
            return dp[n1, n2];
            

        }
    }
}
