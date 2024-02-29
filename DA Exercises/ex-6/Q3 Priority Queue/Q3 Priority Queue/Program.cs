using System;
using System.Collections.Generic;

namespace Q3_Priority_Queue
{
    public class Edge
    {
        public int To { get; set; }
        public int Weight { get; set; }

        public Edge(int to, int weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public class PriorityQueue<T>
    {
        private readonly List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

        public int Count => elements.Count;

        public void Enqueue(T item, int priority)
        {
            elements.Add(Tuple.Create(item, priority));
        }

        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Item2 < elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }
    }

    public class Prim
    {
        public static int FindMinimumWeight(List<Edge>[] graph)
        {
            int n = graph.Length;
            int[] minWeight = new int[n];
            bool[] used = new bool[n];
            PriorityQueue<int> pq = new PriorityQueue<int>();

            for (int i = 0; i < n; i++) minWeight[i] = int.MaxValue;
            minWeight[0] = 0;
            pq.Enqueue(0, 0);

            int totalWeight = 0;

            while (pq.Count > 0)
            {
                int u = pq.Dequeue();

                if (!used[u])
                {
                    totalWeight += minWeight[u];
                    used[u] = true;

                    foreach (Edge edge in graph[u])
                    {
                        if (!used[edge.To] && edge.Weight < minWeight[edge.To])
                        {
                            minWeight[edge.To] = edge.Weight;
                            pq.Enqueue(edge.To, edge.Weight);
                        }
                    }
                }
            }

            return totalWeight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int v = int.Parse(input[0]);
            int e = int.Parse(input[1]);

            List<Edge>[] graph = new List<Edge>[v];
            for (int i = 0; i < v; i++) graph[i] = new List<Edge>();

            for (int i = 0; i < e; i++)
            {
                string[] edgeInput = Console.ReadLine().Split(' ');
                int u = int.Parse(edgeInput[0]) - 1;
                int z = int.Parse(edgeInput[1]) - 1;
                int w = int.Parse(edgeInput[2]);

                graph[u].Add(new Edge(z, w));
                graph[z].Add(new Edge(u, w));
            }

            int result = Prim.FindMinimumWeight(graph);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
