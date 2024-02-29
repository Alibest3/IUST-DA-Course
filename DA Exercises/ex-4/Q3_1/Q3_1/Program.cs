using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int v = int.Parse(input[0]);
            int e = int.Parse(input[1]);
            int s = int.Parse(input[2]);

            List<int>[] adjacencyList;
            adjacencyList = new List<int>[v + 1];
            for (int i = 1; i <= v; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            for (int i = 0; i < e; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int u = int.Parse(edge[0]);
                int w = int.Parse(edge[1]);
                adjacencyList[u].Add(w);
                adjacencyList[w].Add(u);

            }

            Queue<int> queue = new Queue<int>();

            List<int> visited = new List<int>();

            visited.Add(s);
            queue.Enqueue(s);

            RecursiveBFS(adjacencyList, queue, visited);
            Console.ReadLine();
        }
        static void RecursiveBFS(List<int>[] adjacencyList, Queue<int> queue, List<int> visited)
        {

            if (queue.Count == 0)
            {
                return;
            }


            int vertex = queue.Dequeue();
            Console.WriteLine(vertex);

            foreach (int neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }

            RecursiveBFS(adjacencyList, queue, visited);
        }
    }

    }

