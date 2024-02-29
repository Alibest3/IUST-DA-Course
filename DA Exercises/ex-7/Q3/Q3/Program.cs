using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class DeliverySystem
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int k = int.Parse(input[2]);
            int m = int.Parse(input[1]);
            int n = int.Parse(input[0]);

            Dictionary<int, List<Tuple<int, int>>> graph = new Dictionary<int, List<Tuple<int, int>>>();

            for (int i = 0; i < m; i++)
            {
                string[] edgeInput = Console.ReadLine().Split(' ');
                int t = int.Parse(edgeInput[2]);
                int dest = int.Parse(edgeInput[1]);
                int src = int.Parse(edgeInput[0]);

                if (!graph.ContainsKey(src))
                { 
                    graph[src] = new List<Tuple<int, int>>();
                }

                graph[src].Add(new Tuple<int, int>(dest, t));
            }

            int totalTime = ShortestPath(graph, k, n);
            Console.WriteLine(totalTime);
            Console.ReadLine();
        }

        static int ShortestPath(Dictionary<int, List<Tuple<int, int>>> graph, int startVertex, int numPackages)
        {
            int[] dist = new int[numPackages + 1];
            bool[] visited = new bool[numPackages + 1];

            for (int i = 1; i <= numPackages; i++)
            {
                dist[i] = int.MaxValue;
            }

            dist[startVertex] = 0;

            for (int i = 1; i <= numPackages; i++)
            {
                int u = -1;

                for (int j = 1; j <= numPackages; j++)
                {
                    if (!visited[j] && (u == -1 || dist[j] < dist[u]))
                    {
                        u = j;
                    }
                }

                if (dist[u] == int.MaxValue)
                {
                    break;
                }

                visited[u] = true;

                if (graph.ContainsKey(u))
                {
                    for (int j = 0; j < graph[u].Count; j++)
                    {
                        int v = graph[u][j].Item1;
                        int weight = graph[u][j].Item2;

                        if (dist[u] + weight < dist[v])
                        {
                            dist[v] = dist[u] + weight;
                        }
                    }

                }
            }

            int deliveredPackages = 0;
            int t = 0;
            //List<int> time = new List<int>();
            for (int i = 1; i <= numPackages; i++)
            {
                if (i != startVertex && dist[i] != int.MaxValue)
                {
                    if (dist[i] > t)
                    {
                        t = dist[i];
                    }
                    deliveredPackages++;
                }
            }

            return deliveredPackages >  0 ? t : -1;
        }
    }
}
