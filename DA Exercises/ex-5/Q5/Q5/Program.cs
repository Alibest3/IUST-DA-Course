using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5
{
    class Program
    {
        static List<int>[] tree;
        static bool[] visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            tree = new List<int>[n + 1];

            for (int i = 0; i <= n; i++)
            {
                tree[i] = new List<int>();
            }

            for (int i = 0; i < n - 1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int u = int.Parse(edge[0]);
                int v = int.Parse(edge[1]);

                tree[u].Add(v);
                tree[v].Add(u);
            }

            for (int k = 1; k <= n; k++)
            {
                visited = new bool[n + 1];
                int components = 0;

                for (int i = 1; i <= n; i++)
                {
                    if (!visited[i])
                    {
                        DFS(i, -1, k);
                        components++;
                    }
                }

                Console.Write(components + " ");
            }
            Console.ReadLine();
        }

        static void DFS(int node, int parent, int k)
        {
            visited[node] = true;

            foreach (int child in tree[node])
            {
                if (child != parent && !visited[child])
                {
                    if (GetDistance(node, child) >= k)
                    {
                        DFS(child, node, k);
                    }
                }
            }
        }

        static int GetDistance(int u, int v)
        {
            int distance = 0;
            while (u != v)
            {
                u = u / 2;
                v = v / 2;
                distance++;
            }
            return distance;
        }
    }
}
