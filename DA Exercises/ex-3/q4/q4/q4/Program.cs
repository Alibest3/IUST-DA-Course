using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            
            string[] input = Console.ReadLine().Split();
            int[] stops = new int[n];

            for (int i = 0; i<n; i++)
            {
                stops[i] = int.Parse(input[i]);
            }

            Console.WriteLine(CarFuel(d,m,n,stops));
            Console.ReadLine();
            
        }

        public static int CarFuel(int d, int m, int n, int[] stops)
        {
            int currentPos = 0;
            int refuelsCount = 0;
            int lastRefuelPos = 0;

            while (currentPos + m < d)
            {
                int nextRefuelPos = -1;

                for (int i = lastRefuelPos; i < n && stops[i] - currentPos <= m; i++)
                {
                    nextRefuelPos = i;
                }

                if (nextRefuelPos == -1 || nextRefuelPos == lastRefuelPos)
                {
                    return -1;
                }
                currentPos = stops[nextRefuelPos];
                lastRefuelPos = nextRefuelPos;
                refuelsCount++;
            }


            return refuelsCount;
            
        }
    }
}
