using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int divideNum = Convert.ToInt32(Math.Pow(10, 9)) + 7;
            List<int> numbersList = new List<int>() { 1, 0 };
            int final = numbersList.Sum();
            for (int i =2; i < n; i++)
            {
                numbersList.Add((numbersList[i - 1] + numbersList[i - 2]) % divideNum);
                final = (final + numbersList[i]) % divideNum;
            }
            Console.WriteLine(final);
            Console.ReadLine();
        }
    }
}
