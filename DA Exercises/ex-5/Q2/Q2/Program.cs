using System;
using System.Collections.Generic;

namespace Q2
{
    class Graph
    {
        private int n;
        private Dictionary<int, List<int>> adjList;

        public Graph(int n)
        {
            this.n = n;
            adjList = new Dictionary<int, List<int>>();

            for (int i = 1; i <= n; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        private void DFS(int node, bool[] visited, int[] dist, int d)
        {
            visited[node] = true;
            dist[node] = d;

            foreach (int neighbor in adjList[node])
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, visited, dist, d + 1);
                }
            }
        }

        public int LongestPathLength()
        {
            bool[] visited = new bool[n + 1];
            int[] dist = new int[n + 1];

            DFS(1, visited, dist, 0);

            int maxDist = -1;
            int maxNode = 1;

            for (int i = 1; i <= n; i++)
            {
                if (dist[i] > maxDist)
                {
                    maxDist = dist[i];
                    maxNode = i;
                }
            }

            visited = new bool[n + 1];
            dist = new int[n + 1];

            DFS(maxNode, visited, dist, 0);

            maxDist = -1;

            for (int i = 1; i <= n; i++)
            {
                maxDist = Math.Max(maxDist, dist[i]);
            }

            return maxDist;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Graph graph = new Graph(n);

            for (int i = 0; i < n - 1; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int u = int.Parse(input[0]);
                int v = int.Parse(input[1]);

                graph.AddEdge(u, v);
            }

            Console.WriteLine(graph.LongestPathLength());
            Console.ReadLine();
        }
    }
}
