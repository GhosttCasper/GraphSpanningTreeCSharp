using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSpanningTreeCSharp
{
    public class Edge
    {
        public int Weight;
        public Vertex IncidentFrom;
        public Vertex IncidentTo;

        public Edge(Vertex incidentFrom, Vertex incidentTo, int weight)
        {
            IncidentFrom = incidentFrom;
            IncidentTo = incidentTo;
            Weight = weight;
        }

        public Edge(int weight)
        {
            Weight = weight;
        }
    }
}
