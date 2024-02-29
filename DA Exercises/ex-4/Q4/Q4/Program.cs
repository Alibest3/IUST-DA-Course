using System;
using System.Collections.Generic;


namespace Q4
{

    class Graph
    {
        int vertices;
        public List<int>[] adjacencyList;

        public Graph(int v)
        {
            vertices = v;
            adjacencyList = new List<int>[vertices + 1];

            for (int i = 1; i <= vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u);
        }

        public bool IsConnected(int source, int destination)
        {
            bool[] visited = new bool[vertices+1];
            Queue<int> queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                int u = queue.Dequeue();
                foreach (int v in adjacencyList[u])
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                    }
                    if (v == destination)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split();
            int v = int.Parse(line1[0]);
            int e = int.Parse(line1[1]);

            string[] line2 = Console.ReadLine().Split();
            int A = int.Parse(line2[0]) ;
            int B = int.Parse(line2[1]) ;

            Graph graph = new Graph(v);

            for (int i = 1; i <= v; i++)
            {
                string[] line = Console.ReadLine().Split();
                int k = int.Parse(line[0]);
                for (int j = 1; j <= k; j++)
                {
                    int neighbor = int.Parse(line[j]) ;
                    graph.AddEdge(i, neighbor);
                }
            }

            if (graph.IsConnected(A, B))
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
