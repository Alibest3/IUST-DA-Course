using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int v = int.Parse(input[0]);
            int e = int.Parse(input[1]);
            int s = int.Parse(Console.ReadLine());
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            Stack<int> stack = new Stack<int>();
            stack.Push(s);
            for (int i = 0; i < e; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int u = int.Parse(edge[0]);
                int w = int.Parse(edge[1]);

                if (!graph.ContainsKey(u))
                {
                    graph.Add(u, new List<int>());
                }

                if (!graph.ContainsKey(w))
                {
                    graph.Add(w, new List<int>());
                }

                graph[u].Add(w);
                graph[w].Add(u);
            }
            bool[] visited = new bool[v+1];

            while (stack.Count > 0)
            {
                int t = stack.Pop();
                if (!visited[t])
                { 
                Console.WriteLine(t);
                visited[t] = true;
                
                }

                graph[t].Reverse();
                foreach (int j in graph[t])
                {
                    if (!visited[j])
                    {
                        stack.Push(j);
                    }
                }

            }

            Console.ReadLine();


        }
    }
}
