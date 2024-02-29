using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int v = int .Parse(Console.ReadLine());

            Graph graph = new Graph(v);
            for (int i = 0; i < e; i++)
            {
                string[] edge = Console.ReadLine().Split();
                graph.AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
            }

            bool[] visited = new bool[v+1];
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i <= v; i++)
            {
                if (!visited[i])
                {
                    TopoSort(i,graph, visited, stack);
                }
            }

            List<int> sorted = new List<int>();
            while (stack.Count != 0)
            {
                sorted.Add(stack.Pop());
            }
            for (int i = 0; i < v; i++)
            {
                Console.Write(sorted[i]+" ");
            }
            Console.Read();
        }

        public static void TopoSort(int v,Graph graph, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;
            foreach (int nextNeighbor in graph.adjacencyList[v])
            {
                if (!visited[nextNeighbor])
                {
                    TopoSort(nextNeighbor,graph, visited, stack);
                }
            }
            stack.Push(v);
        }
    }
}
