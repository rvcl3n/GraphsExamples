using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsExamples
{
    class Edge
    {
        public Node nodeA;

        public Node nodeB;

        public int value;

        public Edge(Node nodeA, Node nodeB)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
            this.value = 0;
        }

    }
}
