using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    class Program
    {
        // A class to represent a directed graph
        class Graph
        {
            // The number of vertices in the graph
            int n;

            // An adjacency list to store the edges
            List<int>[] adj;

            // A constructor to initialize the graph
            public Graph(int n)
            {
                this.n = n;
                adj = new List<int>[n];
                for (int i = 0; i < n; i++)
                {
                    adj[i] = new List<int>();
                }
            }

            // A method to add an edge from u to v
            public void AddEdge(int u, int v)
            {
                adj[u].Add(v);
            }

            // A method to check if there is a path from u to v using DFS
            public bool IsPath(int u, int v)
            {
                // A visited array to mark the visited vertices
                bool[] visited = new bool[n];

                // A stack to store the vertices to be explored
                Stack<int> stack = new Stack<int>();

                // Push the source vertex to the stack and mark it as visited
                stack.Push(u);
                visited[u] = true;

                // Loop until the stack is empty
                while (stack.Count > 0)
                {
                    // Pop a vertex from the stack
                    int curr = stack.Pop();

                    // If it is the destination vertex, return true
                    if (curr == v) return true;

                    // For each neighbor of the current vertex
                    foreach (int next in adj[curr])
                    {
                        // If it is not visited, push it to the stack and mark it as visited
                        if (!visited[next])
                        {
                            stack.Push(next);
                            visited[next] = true;
                        }
                    }
                }

                // If the destination vertex is not reached, return false
                return false;
            }

            // A method to find the minimum number of edges required to satisfy the given paths
            public int MinEdges(int m, int[,] paths)
            {
                // A variable to store the result
                int result = 0;

                // Loop through each path
                for (int i = 0; i < m; i++)
                {
                    // Get the source and destination vertices of the path
                    int u = paths[i, 0];
                    int v = paths[i, 1];

                    // If there is no path from u to v in the current graph
                    if (!IsPath(u, v))
                    {
                        // Add an edge from u to v and increment the result
                        AddEdge(u, v);
                        result++;
                    }
                }

                // Return the result
                return result;
            }
        }

        static void Main(string[] args)
        {
            // Read the input from the console
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]); // The number of vertices in the graph
            int m = int.Parse(input[1]); // The number of paths that we want to be exist

            // Create a graph object with n vertices
            Graph g = new Graph(n);

            // A two-dimensional array to store the paths
            int[,] paths = new int[m, 2];

            // Read each path from the console and store it in the array
            for (int i = 0; i < m; i++)
            {
                input = Console.ReadLine().Split();
                int u = int.Parse(input[0]) - 1; // The source vertex of the path (zero-based indexing)
                int v = int.Parse(input[1]) - 1; // The destination vertex of the path (zero-based indexing)
                paths[i, 0] = u;
                paths[i, 1] = v;
            }

            // Find and print the minimum number of edges required to satisfy the given paths
            Console.WriteLine(g.MinEdges(m, paths));
            Console.ReadLine();
        }
    }
}
