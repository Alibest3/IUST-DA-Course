using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[,] coordinates = new int[n, 2];

            for (int i = 0; i < n;i++)
            {
                string[] input = Console.ReadLine().Split();
                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);

                coordinates[i, 0] = x;
                coordinates[i, 1] = y;

            }

            int[] xarray = new int[n];
            int[] yarray = new int[n];

            for (int i = 0; i<n;i++)
            {
                for (int j = 0;j < 1;j++)
                {
                    xarray[i] = j;
                    yarray[i] = j;
                }

            }
            
            for (int i = 0; i < n;i++)
            {
                   
            }
            





            Console.ReadLine();
        }
    }
}


