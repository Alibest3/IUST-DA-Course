using System;
using System.Linq;


namespace quiz4
{
    internal class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] edges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int node1 = int.Parse(Console.ReadLine());
            int node2 = int.Parse(Console.ReadLine());

           int result = ShortestDistanceNode(n, edges, node1, node2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public static int ShortestDistanceNode(int n, int[] edges, int node1, int node2)
        {
            int[] dist1 = new int[n];
            int[] dist2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist1[i] = int.MaxValue;
                dist2[i] = int.MaxValue;
            }

            dist1[node1] = 0;
            dist2[node2] = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (edges[j] != -1)
                    {
                        if (dist1[j] != int.MaxValue)
                        {
                            dist1[edges[j]] = Math.Min(dist1[edges[j]], dist1[j] + 1);
                        }

                        if (dist2[j] != int.MaxValue)
                        {
                            dist2[edges[j]] = Math.Min(dist2[edges[j]], dist2[j] + 1);
                        }
                    }
                }
            }

            int minDistNode = -1;
            int minDist = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int maxDist = Math.Max(dist1[i], dist2[i]);
                if (maxDist < minDist)
                {
                    minDist = maxDist;
                    minDistNode = i;
                }
            }

            return minDistNode;
        }
    }
}

