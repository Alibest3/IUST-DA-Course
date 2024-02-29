using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Edge
    {
        public int source, destination, weight;
    }

    class KruskalAlgorithm
    {
        static int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;
            return Find(parent, parent[i]);
        }

        static void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            parent[xset] = yset;
        }

        static int CompareEdges(Edge a, Edge b)
        {
            return a.weight - b.weight;
        }

        static int Kruskal(Edge[] edges, int V, int E)
        {
            Array.Sort(edges, CompareEdges);

            int[] parent = new int[V];
            for (int i = 0; i < V; i++)
                parent[i] = -1;

            int minWeight = 0;
            int edgesCount = 0;
            for (int i = 0; i < E; i++)
            {
                int x = Find(parent, edges[i].source);
                int y = Find(parent, edges[i].destination);

                if (x != y)
                {
                    minWeight += edges[i].weight;
                    Union(parent, x, y);
                    edgesCount++;
                    if (edgesCount == V - 1) break;
                }
            }
            return minWeight;
        }

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int V = int.Parse(input[0]);
            int E = int.Parse(input[1]);

            Edge[] edges = new Edge[E];
            for (int i = 0; i < E; i++)
            {
                edges[i] = new Edge();
                string[] edgeInfo = Console.ReadLine().Split(' ');
                edges[i].source = int.Parse(edgeInfo[0]) - 1;
                edges[i].destination = int.Parse(edgeInfo[1]) - 1;
                edges[i].weight = int.Parse(edgeInfo[2]);
            }

            int minWeight = Kruskal(edges, V, E);
            Console.WriteLine(minWeight);
            Console.ReadLine();
        }
    }
}
