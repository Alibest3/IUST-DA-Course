using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q4_2
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split();
            int[] stops = new int[n];

            for (int i = 0; i < n; i++)
            {
                stops[i] = int.Parse(input[i]);
            }


            Console.WriteLine(ComputeMinRefills(d, m, stops));
            Console.ReadLine();
        }
            static int ComputeMinRefills(int dist, int tank, int[] stops)
            {
                int numRefills = 0; 
                int currentRefill = 0;
                int n = stops.Length;

                while (currentRefill <= n)
                {
                int lastRefill = currentRefill;

                while (currentRefill <= n)
                {
                    int currentStop = 0;
                    if (currentRefill == n)
                    {
                        currentStop = dist;
                    }
                    else
                    {
                        currentStop = stops[currentRefill];
                    }

                    int lastStop = 0;

                    if (lastRefill == 0)
                    {
                        lastStop = 0;
                    }

                    else
                    {
                        lastStop = stops[lastRefill - 1];
                    }

                    if (currentStop - lastStop <= tank)
                    {
                        currentRefill++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentRefill == lastRefill)
                {
                    return -1;
                }

                if (currentRefill <= n)
                {
                    numRefills++;
                }

                }

                return numRefills;
            }
            
        }
        
    }

