using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class MainClass
    {
        static int[] depth;
        static int[] parent;
        static List<int>[] tree;

        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int q = int.Parse(input[1]);

            depth = new int[n + 1];
            parent = new int[n + 1];
            tree = new List<int>[n + 1];

            for (int i = 1; i <= n; i++)
            {
                tree[i] = new List<int>();
            }

            string[] parents = Console.ReadLine().Split(' ');
            for (int i = 2; i <= n; i++)
            {
                int parentNode = int.Parse(parents[i - 2]);
                tree[i].Add(parentNode);
                tree[parentNode].Add(i);
            }

            DFS(1, 0, -1);

            for (int i = 0; i < q; i++)
            {
                string[] uv = Console.ReadLine().Split();
                int u = int.Parse(uv[0]);
                int v = int.Parse(uv[1]);

                int lca = LCA(u, v);
                Console.WriteLine(lca);
            }
            Console.ReadLine();
        }

        static void DFS(int node, int currentDepth, int parentNode)
        {
            depth[node] = currentDepth;
            parent[node] = parentNode;

            foreach (int child in tree[node])
            {
                if (child != parentNode)
                {
                    DFS(child, currentDepth + 1, node);
                }
            }
        }

        static int LCA(int u, int v)
        {
            while (u != v)
            {
                if (depth[u] > depth[v])
                {
                    u = parent[u];
                }
                else
                {
                    v = parent[v];
                }
            }

            return u;
        }
    }
}
