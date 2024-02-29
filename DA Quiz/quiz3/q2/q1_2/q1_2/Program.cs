
using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<int> x_coords = new List<int>();
        List<int> y_coords = new List<int>();

        for (int i = 0; i < n; i++)
        {
            string[] s = Console.ReadLine().Split(' ');
            int x = int.Parse(s[0]);
            int y = int.Parse(s[1]);
            x_coords.Add(x);
            y_coords.Add(y);
        }

        int max_x = x_coords.Max();
        int min_x = x_coords.Min();
        int max_y = y_coords.Max();
        int min_y = y_coords.Min();

        int width = max_x - min_x;
        int height = max_y - min_y;

        int num_teppeh = (width > height) ? width : height;

        Console.WriteLine(num_teppeh - (n - 1));
    }
}

