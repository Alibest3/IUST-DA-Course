using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximumMatching
{
    static bool FindMatch(int u, int[,] graph, bool[] visited, int[] match)
    {
        int n = graph.GetLength(1);
        
        for (int v = 0; v < n; v++)
        {
            if (graph[u, v] == 1 && !visited[v])
            {
                visited[v] = true;
                if (match[v] == -1 || FindMatch(match[v], graph, visited, match))
                {
                    match[v] = u;
                    return true;
                }
            }
        }
        return false;
    }

    static int[] MaxMatch(int[,] graph,int n , int m)
    {
        int[] match = new int[m + 1];
        for (int i = 1; i <= m; i++)
            match[i] = -1;

        for (int u = 1; u <= n; u++)
        {
            bool[] visited = new bool[m + 1];
            FindMatch(u, graph, visited, match);
        }

        return match;
    }

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[,] graph = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            string[] rowValues = Console.ReadLine().Split(' ');
            
            for (int j = 0; j < m; j++)
            {
                graph[i, j + 1] = int.Parse(rowValues[j]);
            }
        }
        

        int[] matches = MaxMatch(graph,n,m);

        for (int i = 1; i <= n; i++)
        {
            int matchedVertex = -1;
            for (int j = 1; j <= m; j++)
            {
                if (matches[j] == i)
                {
                    matchedVertex = j;
                    break;
                }
            }
            Console.Write(matchedVertex + " ");     
        }
        Console.ReadLine();
    }
}
