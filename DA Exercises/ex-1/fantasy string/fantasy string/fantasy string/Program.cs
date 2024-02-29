using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.WriteLine(fantasyString(str));
            Console.ReadLine();
            
        }
        public static int fantasyString(string str)
        {
            double result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsUpper(str,i))
                {
                    result++;
                }
                
            }
            if (result == str.Length)
            {
                result= 0;
                return Convert.ToInt32(result);
            }
            result = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLower(str, i))
                {
                    result++;
                }

            }
            if (result == str.Length)
            {
                result= 0;
                return Convert.ToInt32(result);
            }
            
            if (str.Length - result > Math.Ceiling(result / 2)) 
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return Convert.ToInt32(str.Length - result);
            }

        }
    }
}
