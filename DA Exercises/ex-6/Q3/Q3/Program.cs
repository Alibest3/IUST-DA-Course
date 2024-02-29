using System;
using System.Collections.Generic;

namespace Q3
{
    class Edge
    {
        public int Src, Dest, Weight;

        public Edge(int src, int dest, int weight)
        {
            Src = src;
            Dest = dest;
            Weight = weight;
        }
    }

    class Graph
    {
        public int V, E;
        public List<Edge> edgeList;

        public Graph(int v, int e)
        {
            V = v;
            E = e;
            edgeList = new List<Edge>();
        }

        public void AddEdge(int src, int dest, int weight)
        {
            edgeList.Add(new Edge(src, dest, weight));
        }

        public int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;

            return Find(parent, parent[i]);
        }

        public void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            parent[xset] = yset;
        }

        public int Prim()
        {
            edgeList.Sort((a, b) => a.Weight.CompareTo(b.Weight));

            int[] parent = new int[V];
            for (int i = 0; i < V; i++)
                parent[i] = -1;

            int numEdges = 0, weight = 0;

            for (int i = 0; i < E && numEdges < V - 1; i++)
            {
                Edge edge = edgeList[i];
                int x = Find(parent, edge.Src);
                int y = Find(parent, edge.Dest);

                if (x != y)
                {
                    Union(parent, x, y);
                    weight += edge.Weight;
                    numEdges++;
                }
            }

            return weight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            int v = int.Parse(firstLine[0]);
            int e = int.Parse(firstLine[1]);

            Graph graph = new Graph(v, e);

            for (int i = 0; i < e; i++)
            {
                string[] edgeData = Console.ReadLine().Split(' ');
                int src = int.Parse(edgeData[0]) - 1;
                int dest = int.Parse(edgeData[1]) - 1;
                int weight = int.Parse(edgeData[2]);

                graph.AddEdge(src, dest, weight);
            }

            int mstWeight = graph.Prim();
            Console.WriteLine(mstWeight);
            Console.ReadLine();
        }
    }
}