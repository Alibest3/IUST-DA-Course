using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine()); 
            int n = int.Parse(Console.ReadLine()); 
            string[] input = Console.ReadLine().Split(); 
            int[] foodCounts = new int[n];

            for(int i = 0 ; i < n;i++)
            {
                foodCounts[i] = int.Parse(input[i]);
            }

            foodCounts = foodCounts.OrderByDescending(x => x).ToArray();

            int emptyPlaces = (foodCounts[0] - 1) * m + 1;

            int totalFoods = foodCounts.Sum();

            

            for(int i = 0; i< n; i++)
            {
                if (foodCounts[0] == foodCounts[i])
                {
                    emptyPlaces--;
                    break;
                }

            }

            int condition = emptyPlaces - (totalFoods - foodCounts[0]);

            if (condition > 0)
            {
                totalFoods += condition;
            }

            Console.WriteLine(totalFoods);
            
            Console.ReadLine();


         
                
        }
    }
}
