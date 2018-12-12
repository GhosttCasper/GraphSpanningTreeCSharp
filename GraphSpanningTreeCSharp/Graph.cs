using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 9. Дан исходный граф G = (X, V). Построить порождённый граф G’ = (X’, V’),
 * который получается из исходного после удаления указанных вершин и инцидентных им ребер.
 * Найти в G’ кратчайший остов.
 */

namespace GraphSpanningTreeCSharp
{
    public class Graph<T> where T : IComparable
    {
        public List<List<Edge>> AdjacencyMatrixRepresentation = new List<List<Edge>>();
        private int Size;

        public Graph(int size, string[] strs)
        {
            Size = size;
            try
            {
                foreach (var str in strs)
                {
                    List<Edge> list = new List<Edge>();
                    var array = str.Split();
                    foreach (var item in array)
                    {
                        int intVar = int.Parse(item);
                        Edge curEdge = new Edge(intVar);
                        list.Add(curEdge);
                    }
                    AdjacencyMatrixRepresentation.Add(list);
                }
            }
            catch (Exception e)
            {
                if (e is NullReferenceException || e is FormatException)
                    Console.WriteLine("String is empty (Graph)");
            }
        }

        public Graph()
        {
        }

        private void a()
        {
            AdjacencyMatrixRepresentation[1][2] = null;

        }
        // minimum-spanning-tree problem
        /*
         * Generic-MST (G, w)
1 А = 0
2 while А не образует основного дерева
3 Найти ребро (и, v), безопасное для А
4 А = A U {(и,г;)}
5 return А
         */

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}