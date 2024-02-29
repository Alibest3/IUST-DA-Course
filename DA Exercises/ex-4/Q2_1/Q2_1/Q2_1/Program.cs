using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int v = int.Parse(input[0]); 
            int e = int.Parse(input[1]); 
            int s = int.Parse(Console.ReadLine());
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


            bool[] visited = new bool[v + 1];
            DFS(s, visited, adjacencyList);

            Console.ReadLine(); 
        }

        public static void DFS(int v, bool[] visited, List<int>[] adjacencyList)
        {
            visited[v] = true;
            Console.WriteLine(v);

            foreach (int neighbor in adjacencyList[v])
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, visited, adjacencyList);
                }
            }

        }
    }
}
