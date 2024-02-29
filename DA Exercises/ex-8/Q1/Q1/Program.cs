using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    class Network
    {
        

        private static void DFS(int[,] residual, int src, bool[] visited)
        {
            visited[src] = true;
            for (int i = 0; i < residual.GetLength(0); i++)
            {
                if (residual[src, i] > 0 && !visited[i])
                {
                    DFS(residual, i, visited);
                }
            }
        }


        private static bool BFS(int[,] residual, int src, int dest, int[] ancestors)
        {
            bool[] visited = new bool[residual.Length];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(src);
            visited[src] = true;
            ancestors[src] = -1;

            while (queue.Count != 0)
            {
                int current = queue.Dequeue();
                for (int i = 0; i < residual.GetLength(0); i++)
                {
                    if (residual[current, i] > 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                        ancestors[i] = current;
                    }
                }
            }

            return visited[dest];
        }
        private static void MinimalCut(int[,] graph, int src, int dest)
        {
            int u, v;
            int[,] residual = new int[graph.Length, graph.Length];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    residual[i, j] = graph[i, j];
                }
            }

            int[] ancestors = new int[graph.Length];

            while (BFS(residual, src, dest, ancestors))
            {
                int minFlow = int.MaxValue;
                for (v = dest; v != src; v = ancestors[v])
                {
                    u = ancestors[v];
                    minFlow = Math.Min(minFlow, residual[u, v]);
                }

                for (v = dest; v != src; v = ancestors[v])
                {
                    u = ancestors[v];
                    residual[u, v] -= minFlow;
                    residual[v, u] += minFlow;
                }
            }

            bool[] visited = new bool[graph.Length];
            DFS(residual, src, visited);

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 && visited[i] && !visited[j])
                    {
                        Console.WriteLine(i + " - " + j);
                    }
                }
            }
        }

        public static void Main(String[] args)
        {
            int numVertices = int.Parse(Console.ReadLine());
            int source = int.Parse(Console.ReadLine());
            int sink = int.Parse(Console.ReadLine());
            int[,] graph = new int[numVertices, numVertices];

            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    graph[i, j] = 0;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "-1")
            {
                string[] parts = input.Split(' ');
                int n1 = int.Parse(parts[0]);
                int n2 = int.Parse(parts[1]);
                int value = int.Parse(parts[2]);
                graph[n1, n2] = value;
            }

            MinimalCut(graph, source, sink);
            Console.ReadLine();
        }
    }
}
