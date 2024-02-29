using System;
using System.Collections.Generic;

namespace Q2_2
{

    class Program
    {
        static void Main(string[] args)
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
            Stack<int> stack = new Stack<int>();
            stack.Push(s);
            while (stack.Count > 0)
            {
                int t = stack.Pop();
                if (!visited[t])
                {
                    Console.WriteLine(t);
                    visited[t] = true;

                }

                adjacencyList[t].Reverse();
                foreach (int j in adjacencyList[t])
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
