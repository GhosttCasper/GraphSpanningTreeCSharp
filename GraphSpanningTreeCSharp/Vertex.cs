using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSpanningTreeCSharp
{
    public class Vertex
    {
        public int Color { get; set; }
        public int Index { get; }

        public int Key { get; set; }    // минимальный вес среди всех ребер, соединяющих v с вершиной в дереве.
        public Vertex Parent { get; set; }
        public bool Discovered { get; set; }

        public List<IncidentEdge> AdjacencyList { get; }

        //public int Distance;
        //public int DiscoveryTime;
        //public int FinishingTime;

        public Vertex(int index)
        {
            Index = index;
            Color = index - 1;
            Key = int.MaxValue;
            AdjacencyList = new List<IncidentEdge>();
        }
    }
}
