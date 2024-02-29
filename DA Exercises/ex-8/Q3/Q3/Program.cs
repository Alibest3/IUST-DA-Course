using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class MaxFlowWithNodeCapacity
    {
        static int[,] residualGraph;
        static int[] capacities;
        static int[] parent;
        static int source, sink, numberOfNodes, numberOfEdges;

        static int BFS()
        {
            bool[] visited = new bool[numberOfNodes];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            parent[source] = -1;

            while (queue.Count != 0)
            {
                int currentNode = queue.Dequeue();

                for (int nextNode = 0; nextNode < numberOfNodes; nextNode++)
                {
                    if (!visited[nextNode] && residualGraph[currentNode, nextNode] > 0)
                    {
                        parent[nextNode] = currentNode;
                        visited[nextNode] = true;
                        queue.Enqueue(nextNode);

                        if (nextNode == sink)
                            return Math.Min(capacities[currentNode], residualGraph[currentNode, nextNode]);
                    }
                }
            }

            return 0;
        }

        static int MaxFlow()
        {
            int maxFlow = 0;
            parent = new int[numberOfNodes];

            while (true)
            {
                int pathFlow = BFS();

                if (pathFlow == 0)
                    break;

                maxFlow += pathFlow;
                int currentNode = sink;

                while (currentNode != source)
                {
                    int previousNode = parent[currentNode];
                    residualGraph[previousNode, currentNode] -= pathFlow;
                    residualGraph[currentNode, previousNode] += pathFlow;
                    currentNode = previousNode;
                }
            }

            return maxFlow;
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            numberOfNodes = int.Parse(input[0]);
            numberOfEdges = int.Parse(input[1]);

            residualGraph = new int[numberOfNodes, numberOfNodes];

            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] edgeInput = Console.ReadLine().Split();
                int u = int.Parse(edgeInput[0]) - 1;
                int v = int.Parse(edgeInput[1]) - 1;
                int capacity = int.Parse(edgeInput[2]);

                residualGraph[u, v] = capacity;
            }

            capacities = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[] sourceSink = Console.ReadLine().Split();
            source = int.Parse(sourceSink[0]) - 1;
            sink = int.Parse(sourceSink[1]) - 1;

            Console.WriteLine(MaxFlow());
            Console.ReadLine()
        }
    }
}
