using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsExamples
{
    class Graph
    {
        List<Edge> edges;

        public Graph()
        {
            edges = new List<Edge>();
        }

        public void AddConnection(Edge edge)
        {
            if(edges.Contains(edge))
            {
                Console.WriteLine("This edge is already added");
                return;
            }

            foreach (var edgeInGraph in edges)
            {
                if(
                    (edgeInGraph.nodeA == edge.nodeA && edgeInGraph.nodeB == edge.nodeB)
                    ||
                    (edgeInGraph.nodeA == edge.nodeB && edgeInGraph.nodeB == edge.nodeA)
                    )
                {
                    Console.WriteLine($"This connection already exsists: {edge.nodeA.name} === {edge.nodeB.name}");
                    return;
                }
            }

            edges.Add(edge);
        }

        public void PrintGraph()
        {
            foreach (var edge in edges)
            {
                Console.WriteLine(edge.nodeA.name +" === "+ edge.nodeB.name);
            }
        }
    }
}
