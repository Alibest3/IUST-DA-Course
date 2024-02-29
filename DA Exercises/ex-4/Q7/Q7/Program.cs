using System;
using System.Collections.Generic;

namespace Q7
{

    class SinglyConnectedGraph
    {
        private int v;
        private List<int>[] adj;

        public SinglyConnectedGraph(int v)
        {
            this.v = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int w)
        {
            adj[u].Add(w);
        }

        public bool IsSinglyConnected()
        {
            // Create a matrix to store the shortest distance between any two vertices
            int[,] dist = new int[v, v];
            for (int i = 0; i < v; ++i)
            {
                for (int j = 0; j < v; ++j)
                {
                    if (i == j)
                    {
                        dist[i, j] = 0;
                    }
                    else
                    {
                        dist[i, j] = int.MaxValue;
                    }
                }
            }

            // Initialize the distances using the edges of the graph
            for (int i = 0; i < v; ++i)
            {
                foreach (int j in adj[i])
                {
                    dist[i, j] = 1;
                }
            }

            // Use Floyd-Warshall algorithm to compute the shortest distance between any two vertices
            for (int k = 0; k < v; ++k)
            {
                for (int i = 0; i < v; ++i)
                {
                    for (int j = 0; j < v; ++j)
                    {
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                            dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            // Check if there are any pairs of vertices with more than one path between them
            for (int i = 0; i < v; ++i)
            {
                for (int j = 0; j < v; ++j)
                {
                    if (dist[i, j] > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            int e = int.Parse(firstLine[0]);
            int v = int.Parse(firstLine[1]);

            SinglyConnectedGraph g = new SinglyConnectedGraph(v);
            for (int i = 0; i < e; ++i)
            {
                string[] line = Console.ReadLine().Split();
                int u = int.Parse(line[0]);
                int w = int.Parse(line[1]);
                g.AddEdge(u, w);
            }

            if (g.IsSinglyConnected())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            Console.ReadLine();
        }
    }
}




        
