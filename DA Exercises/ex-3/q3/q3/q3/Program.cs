using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] intervals = new int[n][ ];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                intervals[i] = new int[] { int.Parse(input[0]), int.Parse(input[1]) };
            }

            Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

            int count = 0;
            int last = -1;
            for (int i = 0; i < n; i++)
            {
                if (intervals[i][0] > last)
                {
                    last = intervals[i][1];
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

    }
}
