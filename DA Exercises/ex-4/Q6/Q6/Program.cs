using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int e = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            List<int>[] adjacencyList = new List<int>[v + 1];
            for (int i = 1; i <= v; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                string[] input = Console.ReadLine().Split();
                int u = int.Parse(input[0]);
                int w = int.Parse(input[1]);
                adjacencyList[u].Add(w);
                adjacencyList[w].Add(u);
            }
            bool[] visited = new bool[v + 1];
            int count = 0;

            for (int i = 1; i <= v; i++)
            {
                if (!visited[i])
                {
                    DFS(i, adjacencyList, visited);
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
        public static void DFS(int v, List<int>[] adjList, bool[] visited)
        {
            visited[v] = true;

            foreach (int neighbor in adjList[v])
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, adjList, visited);
                }
            }
        }
    }
}
