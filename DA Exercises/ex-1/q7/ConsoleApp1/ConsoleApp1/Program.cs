using System;
using System.Collections;


namespace Hungry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(input[0]);
            int p = Convert.ToInt32(input[1]);
            int[] array1 = new int[n];
            int[] array2 = new int[n];
            array1 = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            array2 = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            Stack way1= new Stack();
            Stack way2= new Stack();
            way1.Push(array1[0]);
            way2.Push(array2[0]);
            int firstPath;
            int secondPath;
            for (int i = 1; i < n; i++)
            {
                if (Convert.ToInt32(way1.Peek()) > Convert.ToInt32(way2.Peek()) - p)
                {
                    firstPath = Convert.ToInt32(way1.Peek()) + array1[i];
                }
                else
                {
                    firstPath = Convert.ToInt32(way2.Peek()) + array1[i] - p;
                }  

                if (Convert.ToInt32(way1.Peek()) - p < Convert.ToInt32(way2.Peek()))
                {
                    secondPath = Convert.ToInt32(way2.Peek()) + array2[i];
                }
                else
                {
                    secondPath = Convert.ToInt32(way1.Peek()) + array2[i] - p;
                }

                way1.Push(firstPath);
                way2.Push(secondPath);
            }

            /*if (Convert.ToInt32(way2.Peek()) > Convert.ToInt32(way1.Peek()))
            {
                Console.WriteLine(way2.Peek());
            }
            else
            {
                Console.WriteLine(way1.Peek());
            }*/
            Console.WriteLine(Convert.ToInt32(way2.Peek()) > Convert.ToInt32(way1.Peek()) ? Convert.ToInt32(way2.Peek()) : Convert.ToInt32(way1.Peek()));
            Console.ReadLine();


        }
    }
}
