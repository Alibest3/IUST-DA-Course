using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3_2
{


   

    class Program
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

            BFS(s, v, adjacencyList);
            Console.ReadLine();
        }
        public static void BFS(int s,int v, List<int>[] adjacencyList)
        {
            bool[] visited = new bool[v + 1];

            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                int currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex);

                foreach (int neighbor in adjacencyList[currentVertex])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }

        }
    }
}
