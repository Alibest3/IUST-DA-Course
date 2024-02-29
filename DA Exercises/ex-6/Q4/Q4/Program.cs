using System;
using System.Collections.Generic;
using System.Linq;

namespace Q4
{
    class Edge
    {
        public int u, v, w;
        public Edge(int u, int v, int w)
        {
            this.u = u;
            this.v = v;
            this.w = w;
        }
    }

    class Kruskal
    {
        private int[] parent;
        private int[] rank;

        public Kruskal(int size)
        {
            parent = new int[size];
            rank = new int[size];

            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY) return false;

            if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int V = int.Parse(input[0]);
            int E = int.Parse(input[1]);

            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < E; i++)
            {
                input = Console.ReadLine().Split(' ');
                int u = int.Parse(input[0]) - 1;
                int v = int.Parse(input[1]) - 1;
                int w = int.Parse(input[2]);

                edges.Add(new Edge(u, v, w));
            }

            edges.Sort((a, b) => a.w.CompareTo(b.w));

            Kruskal uf = new Kruskal(V);
            List<Edge> mst = new List<Edge>();
            int cost = 0;

            foreach (Edge edge in edges)
            {
                if (uf.Union(edge.u, edge.v))
                {
                    mst.Add(edge);
                    cost += edge.w;
                }
            }

            if (mst.Count < V - 1)
            {
                Console.WriteLine(-1);
                Console.ReadLine();
            }

            int secondMinCost = int.MaxValue;

            foreach (Edge excludedEdge in mst)
            {
                uf = new Kruskal(V);
                int currentCost = 0;
                int count = 0;

                foreach (Edge edge in edges)
                {
                    if (edge != excludedEdge && uf.Union(edge.u, edge.v))
                    {
                        currentCost += edge.w;
                        count++;
                    }
                }

                if (count == V - 1)
                {
                    secondMinCost = Math.Min(secondMinCost, currentCost);
                }
            }

            if (secondMinCost == int.MaxValue)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(secondMinCost);
            }
            Console.ReadLine();
        }
    }
}
