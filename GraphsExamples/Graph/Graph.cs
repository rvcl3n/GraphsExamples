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
            try
            {
                if (edges.Contains(edge))
                {
                    throw new ExistingEdgeException("This edge is already added");
                }

                foreach (var edgeInGraph in edges)
                {
                    if (
                        (edgeInGraph.nodeA == edge.nodeA && edgeInGraph.nodeB == edge.nodeB)
                        ||
                        (edgeInGraph.nodeA == edge.nodeB && edgeInGraph.nodeB == edge.nodeA)
                        )
                    {
                        throw new ExistingEdgeException($"This connection already exsists: {edge.nodeA.name} === {edge.nodeB.name}");
                    }
                }

                edges.Add(edge);
            }
            catch (ExistingEdgeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
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
