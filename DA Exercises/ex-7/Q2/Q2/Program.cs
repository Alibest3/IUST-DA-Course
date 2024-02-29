using System;
using System.Collections.Generic;
using System.Linq;

namespace Q2
{
    class ShortestPath
    {
        static int AccessibleVertices(int V, List<(int, int, int)> edges, int maxMoves)
        {
            const int INF = int.MaxValue;

            var adjList = new List<(int, int)>[V];
            for (int i = 0; i < V; i++)
            {
                adjList[i] = new List<(int, int)>();
            }

            for (int i = 0; i < edges.Count; i++)
            {
                int u = edges[i].Item1;
                int v = edges[i].Item2;
                int c = edges[i].Item3;

                adjList[u].Add((v, c + 1));
                adjList[v].Add((u, c + 1));
            }

            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = INF;
            }
            dist[0] = 0;

            var pq = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            {
                int cmp = a.Item1.CompareTo(b.Item1);
                if (cmp == 0)
                {
                    return a.Item2.CompareTo(b.Item2);
                }
                return cmp;
            }));

            pq.Add((0, 0));  

            while (pq.Count > 0)
            {
                var (curDist, u) = pq.First();
                pq.Remove(pq.First());

                if (curDist > dist[u]) continue;

                for (int i = 0; i < adjList[u].Count; i++)
                {
                    int v = adjList[u][i].Item1;
                    int weight = adjList[u][i].Item2;

                    int newDist = curDist + weight;

                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        pq.Add((newDist, v));
                    }
                }

            }

            int count = 0;
            for (int i = 0; i < V; i++)
            {
                if (dist[i] <= maxMoves)
                {
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int V = int.Parse(input[0]);
            int E = int.Parse(input[1]);
            List<(int, int, int)> edges = new List<(int, int, int)>();


            for (int i = 0; i < E; i++)
            {
                input = Console.ReadLine().Split();
                edges.Add((int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2])));

            }
            int maxMoves = int.Parse(Console.ReadLine());

            int result = AccessibleVertices(V, edges, maxMoves);
            Console.WriteLine(result);  
            Console.ReadLine();
        }
    }
}
