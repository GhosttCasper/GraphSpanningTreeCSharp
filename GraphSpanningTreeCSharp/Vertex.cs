using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSpanningTreeCSharp
{
    public class Vertex
    {
        public int Color;
        public int Index;

        public int Key; // минимальный вес среди всех ребер, соединяющих v с вершиной в дереве.
        public Vertex Parent;
        public bool Discovered;

        public List<IncidentEdge> AdjacencyList;

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
