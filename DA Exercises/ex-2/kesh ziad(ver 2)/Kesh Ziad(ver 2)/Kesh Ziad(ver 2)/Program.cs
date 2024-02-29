using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kesh_Ziad_ver_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            int[] tiles = new int[n];
            for (int i = 0; i < n; i++)
            {
                tiles[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(tiles);

            int left = 0;
            int right = m;
            int cost = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int total_cost = 0;
                bool can_reach = true;

                for (int i = 0; i < n; i++)
                {
                    int current_area = tiles[i] * tiles[i];
                    int target_area = mid - current_area;

                    if (target_area < 0)
                    {
                        can_reach = false;
                        break;
                    }

                    int new_side_length1 = (int)Math.Sqrt(target_area) + 1;
                    int new_side_length2 = (int)Math.Sqrt(target_area);

                    int new_area1 = new_side_length1 * new_side_length1;
                    int new_area2 = new_side_length2 * new_side_length2;

                    int new_side_length = 0;
                    int new_area = 0;
                    int conversion_cost = 0;

                    if (new_area1 == target_area)
                    {
                        new_side_length = new_side_length1;
                        new_area = new_area1;
                        conversion_cost = (tiles[i] - new_side_length) * (tiles[i] - new_side_length);
                    }
                    else if (new_area2 == target_area)
                    {
                        new_side_length = new_side_length2;
                        new_area = new_area2;
                        conversion_cost = (tiles[i] - new_side_length) * (tiles[i] - new_side_length);
                    }
                    else
                    {
                        can_reach = false;
                        break;
                    }

                    total_cost += conversion_cost;
                }

                if (can_reach)
                {
                    cost = total_cost;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            Console.WriteLine(cost);
            Console.ReadLine();
        }
    }

}

