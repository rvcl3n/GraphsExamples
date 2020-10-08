using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GraphsExamples
{
    public class Graph
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
                        (edgeInGraph.NodeA == edge.NodeA && edgeInGraph.NodeB == edge.NodeB)
                        ||
                        (edgeInGraph.NodeA == edge.NodeB && edgeInGraph.NodeB == edge.NodeA)
                        )
                    {
                        throw new ExistingEdgeException($"This connection already exsists: {edge.NodeA.Name} === {edge.NodeB.Name}");
                    }
                }

                edges.Add(edge);
            }
            catch (ExistingEdgeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch
            {
                throw;
            }
        }

        public void PrintGraph()
        {
            foreach (var edge in edges)
            {
                Console.WriteLine(edge.NodeA.Name +" === "+ edge.NodeB.Name);
            }
        }

        public List<Node> GetRelatedNodes(Node node) 
        {
            var relatedNodes = new List<Node>();

            foreach (var edge in edges)
            {
                if(edge.NodeA == node && !relatedNodes.Contains(edge.NodeB))
                {
                    relatedNodes.Add(edge.NodeB);
                }
                if(edge.NodeB == node && !relatedNodes.Contains(edge.NodeA))
                {
                    relatedNodes.Add(edge.NodeA);
                }
            }

            return relatedNodes;
        }
        
        public bool ContainsAndRelated(Node node)
        {
            foreach (var edge in edges)
            {
                if(edge.NodeA == node || edge.NodeB == node)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
