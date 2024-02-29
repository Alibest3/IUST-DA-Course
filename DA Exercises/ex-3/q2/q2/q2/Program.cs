using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputNW = Console.ReadLine().Split(' ');
            int w = Convert.ToInt32(inputNW[0]);
            int n = Convert.ToInt32(inputNW[1]);

            string[] inputC = Console.ReadLine().Split(' ');

            int[] costs = new int[n];

            string[] inputW = Console.ReadLine().Split(' ');

            int[] weights = new int[n];

            for (int i = 0; i <n; i++)
            {
                costs[i] = Convert.ToInt32(inputC[i]);
                weights[i] = Convert.ToInt32(inputW[i]);
            }

            Tuple<double, int>[] costPerWeightAndIndex = new Tuple<double, int>[n];

            for (int i = 0; i < n; i++)
            {
                costPerWeightAndIndex[i] = new Tuple<double, int>((double)costs[i] / weights[i], i);
            }

            int[] sortedIndices = costPerWeightAndIndex.OrderByDescending(x => x.Item1)
                                                       .ThenBy(x => weights[x.Item2])
                                                       .Select(x => x.Item2)
                                                       .ToArray();

            int currentWeight = 0;
            double totalValue = 0;

            foreach (int i in sortedIndices)
            {
                if (currentWeight + weights[i] <= w)
                {
                    currentWeight += weights[i];
                    totalValue += costs[i];
                }

                else
                {
                    int remainingCapacity = w - currentWeight;
                    double fractionalWeight = (double)remainingCapacity / weights[i];
                    totalValue += fractionalWeight * costs[i];
                    break;
                }
            }

            totalValue = Convert.ToDouble(string.Format("{0:0.##}", totalValue));

            Console.WriteLine(totalValue);
            Console.ReadLine();
        }

    }

    }


