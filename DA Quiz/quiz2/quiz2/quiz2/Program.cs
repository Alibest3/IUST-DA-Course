using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();

                int firstIndex = 0;
                int secondIndex = 0;

                while (firstIndex < first.Length && secondIndex < second.Length)
                {
                    if (first[firstIndex] == second[secondIndex])
                    {
                        firstIndex++;
                        secondIndex++;
                    }
                    else
                    {
                        firstIndex++;
                    }
                }
                if (secondIndex != second.Length)
                {
                    string s = string.Empty;
                    for (int j = second.Length - 1; j > -1; j--)
                    {
                        s += second[j];
                    }
                    second = s;
                    firstIndex = 0;
                    secondIndex = 0;
                    while (firstIndex < first.Length && secondIndex < second.Length)
                    {
                        if (first[firstIndex] == second[secondIndex])
                        {
                            firstIndex++;
                            secondIndex++;
                        }
                        else
                        {
                            firstIndex++;
                        }
                    }

                }

                if (secondIndex == second.Length)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            Console.ReadLine();
        }
    }
}
