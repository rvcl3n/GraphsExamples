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
