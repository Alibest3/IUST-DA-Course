using System;
using System.Collections.Generic;

namespace Q1
{
    class Graph
    {
        public int Vertices;
        public List<Tuple<int, int, int>> Edges;

        public Graph(int v)
        {
            Vertices = v;
            Edges = new List<Tuple<int, int, int>>();
        }

        public void AddEdge(int u, int z, int d)
        {
            Edges.Add(new Tuple<int, int, int>(u, z, d));
        }

        public void DetectNegativeCycle()
        {
            int[] distances = new int[Vertices];
            int[] predecessors = new int[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                distances[i] = int.MaxValue;
                predecessors[i] = -1;
            }

            distances[0] = 0;

            for (int i = 1; i < Vertices; i++)
            {
                foreach (var edge in Edges)
                {
                    int u = edge.Item1;
                    int z = edge.Item2;
                    int d = edge.Item3;

                    if (distances[u] != int.MaxValue && distances[u] + d < distances[z])
                    {
                        distances[z] = distances[u] + d;
                        predecessors[z] = u;
                    }
                }
            }

            int negativeCycleStart = -1;
            foreach (var edge in Edges)
            {
                int u = edge.Item1;
                int z = edge.Item2;
                int d = edge.Item3;

                if (distances[u] != int.MaxValue && distances[u] + d < distances[z])
                {
                    negativeCycleStart = z;
                    break;
                }
            }

            if (negativeCycleStart == -1)
            {
                Console.WriteLine(-1);
            }
            else
            {
                List<int> cycle = new List<int>();
                int current = negativeCycleStart;
                for (int i = 0; i < Vertices; i++)
                {
                    current = predecessors[current];
                }

                int start = current;
                int first = start;
                cycle.Add(start);
                current = predecessors[start];
                while (current != start)
                {
                    cycle.Add(current);
                    current = predecessors[current];
                }
                cycle.Add(first);
                cycle.Reverse();

                Console.WriteLine(string.Join(" ", cycle));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] inputLine = Console.ReadLine().Split(' ');
            int v = int.Parse(inputLine[0]);
            int e = int.Parse(inputLine[1]);

            Graph graph = new Graph(v);

            for (int i = 0; i < e; i++)
            {
                inputLine = Console.ReadLine().Split(' ');
                int u = int.Parse(inputLine[0]);
                int z = int.Parse(inputLine[1]);
                int d = int.Parse(inputLine[2]);

                graph.AddEdge(u, z, d);
            }

            graph.DetectNegativeCycle();
            Console.ReadLine();
        }
    }
    
}
