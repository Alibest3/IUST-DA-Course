using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = Convert.ToInt32(Console.ReadLine());
            string[] array= Console.ReadLine().Split(' ');
            int[] numsArray= new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                numsArray[i] = Convert.ToInt32(array[i]);
            }
            int[] dp = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                dp[i] = 0;
            }
            for (int i = 0; i < arrayLength; i++)
            {
                int c = 0;
                for (int j = 0; j < arrayLength; j++)
                {
                    if (numsArray[i] == numsArray[j])
                    {
                        if (c + 1 > dp[j])
                        {
                            dp[j] = c + 1;
                        }
                    }
                    if (numsArray[i] > numsArray[j])
                        if (dp[j] > c)
                            c = dp[j];
                }
            }
            int LCISLength = 0;
            for (int i = 0; i < arrayLength; i++)
                if (dp[i] > LCISLength)
                    LCISLength = dp[i];

            Console.WriteLine(LCISLength);
            Console.ReadLine();
        }
    }
}