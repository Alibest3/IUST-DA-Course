using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int W = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            int[] values = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] weights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            double[] ratios = new double[n];
            for (int i = 0; i < n; i++)
            {
                ratios[i] = (double)values[i] / weights[i];
            }

            Array.Sort(ratios, weights);
            Array.Reverse(ratios);
            Array.Reverse(weights);

            double maxValue = 0;
            int remainingWeight = W;

            for (int i = 0; i < n && remainingWeight > 0; i++)
            {
                if (weights[i] <= remainingWeight)
                {
                    maxValue += values[i];
                    remainingWeight -= weights[i];
                }
                else
                {
                    double fraction = (double)remainingWeight / weights[i];
                    maxValue += values[i] * fraction;
                    remainingWeight = 0;
                }
            }

            Console.WriteLine(maxValue);
            Console.ReadLine();
        }
    }
}
