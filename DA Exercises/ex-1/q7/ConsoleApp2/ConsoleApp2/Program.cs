using System;
using System.Linq;


namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = Convert.ToInt32(input[0]);
            int p = Convert.ToInt32(input[1]);

            string[] inputArray1 = Console.ReadLine().Split(' ');
            string[] inputArray2 = Console.ReadLine().Split(' ');
            inputArray1 = new ArraySegment<string>(inputArray1, 0, n).ToArray();
            inputArray2 = new ArraySegment<string>(inputArray2, 0, n).ToArray();

            long[] array1 = new long[n];
            long[] array2 = new long[n];
            for(int i = 0; i < n; i++)
            {
                array1[i] = Convert.ToInt64(inputArray1[i]);
                array2[i] = Convert.ToInt64(inputArray2[i]);    
            }
            long first = array1[0];
            long second = array2[0];
            
            
            
            for (int i = 1; i < n; i++)
            {
                long one = Math.Max(first + array1[i], second + array1[i] - p);

                long two = Math.Max(second + array2[i], first + array2[i] - p);
                
                first = one;
                second = two;
            }
            

            Console.WriteLine(Math.Max(first, second));
            Console.ReadLine();
        }
    }
}
