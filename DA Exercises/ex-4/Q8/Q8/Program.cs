using System;
using System.Collections.Generic;

namespace Q8
{
    class Graph
    {
        private int V; 
        private List<int>[] adj; 

        public Graph(int V)
        {
            this.V = V;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adj[u].Add(v);
        }

        public void DFS(int v, bool[] visited)
        {
            visited[v] = true;

            foreach (int i in adj[v])
            {
                if (!visited[i])
                {
                    DFS(i, visited);
                }
            }
        }

        public Graph GetTranspose()
        {
            Graph g = new Graph(V);
            for (int v = 0; v < V; v++)
            {
                foreach (int i in adj[v])
                {
                    g.adj[i].Add(v);
                }
            }
            return g;
        }

        public void FillOrder(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;

            foreach (int i in adj[v])
            {
                if (!visited[i])
                {
                    FillOrder(i, visited, stack);
                }
            }

            stack.Push(v);
        }

        public void SCC()
        {
            Stack<int> stack = new Stack<int>();

            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    FillOrder(i, visited, stack);
                }
            }

            Graph gr = GetTranspose();

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
            }

            int count = 0;
            while (stack.Count > 0)
            {
                int v = stack.Pop();

                if (!visited[v])
                {
                    gr.DFS(v, visited);
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int V = int.Parse(input[0]); 
            int E = int.Parse(input[1]);

            Graph g = new Graph(V);

            for (int i = 0; i < E; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int u = int.Parse(edge[0]);
                int v = int.Parse(edge[1]);
                g.AddEdge(u - 1, v - 1); 
            }

            g.SCC();
        }
    }
}
