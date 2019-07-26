using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSpanningTreeCSharp
{
    public class Edge
    {
        public Vertex First { get; }  // IncidentFrom выходит (начало)
        public Vertex Second { get; } // IncidentTo входит (конец)
        public int Weight { get; }
        public bool InTree { get; set; }

        public Edge(Vertex incidentFrom, Vertex incidentTo, int weight)
        {
            First = incidentFrom;
            Second = incidentTo;
            Weight = weight;
            InTree = false;
        }

    }

    public class IncidentEdge
    {
        public int Weight { get; }
        public Vertex IncidentTo { get; } // входит (конец)

        public IncidentEdge(Vertex incidentTo, int weight)
        {
            IncidentTo = incidentTo;
            Weight = weight;
        }
    }
}
