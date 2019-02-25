using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSpanningTreeCSharp
{
    public class Vertex
    {
        public bool Discovered;
        public Vertex Parent;
        public int Distance;
        public int Index;
        public int Key; // минимальный вес среди всех ребер, соединяющих v с вершиной в дереве.
        public int DiscoveryTime;
        public int FinishingTime;

        public Vertex(int index)
        {
            Index = index;
            Discovered = false;
        }
    }
}
