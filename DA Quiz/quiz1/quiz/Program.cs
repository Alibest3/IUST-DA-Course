using System;
using System.Collections.Generic;
using System.Linq;

namespace quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);

            int[] array = new int[n];
            int[] indexes = new int[m];

            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < m; i++)
            {
                indexes[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] uniqueCounts = new int[m];
            Dictionary<int, int> indexToUniqueCount = new Dictionary<int, int>();
            HashSet<int> uniqueNumbers = new HashSet<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                uniqueNumbers.Add(array[i]);
                indexToUniqueCount[i + 1] = uniqueNumbers.Count;
            }

            for (int i = 0; i < m; i++)
            {
                uniqueCounts[i] = indexToUniqueCount[indexes[i]];
            }

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(uniqueCounts[i]);
            }

            Console.ReadLine();
        }
    }
}
