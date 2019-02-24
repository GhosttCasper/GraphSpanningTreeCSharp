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
    public class Graph
    {
        public List<List<Vertex>> AdjacencyList = new List<List<Vertex>>();
        //public List<Vertex> Vertices = new List<Vertex>();
        //public List<Edge> Edges = new List<Edge>();
        private int Size;

        public Graph(int size, string[] strs)
        {
            Size = size;
            try
            {
                foreach (var str in strs)
                {
                    List<Vertex> list = new List<Vertex>();
                    var array = str.Split();
                    if (!string.IsNullOrEmpty(str))
                        foreach (var item in array)
                        {
                            int intVar = int.Parse(item);
                            if (intVar > Size)
                                throw new Exception("The vertex is missing");
                            Vertex curVertex = new Vertex(intVar);
                            list.Add(curVertex);
                        }
                    AdjacencyList.Add(list);
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

        public Graph(Graph previousGraph) // Copy constructor.
        {
            AdjacencyList = previousGraph.AdjacencyList;
            Size = previousGraph.Size;
        }

        public void BuildInducedGraph(List<int> verticesIndexes)
        {
            foreach (var vertexIndex in verticesIndexes)
            {
                int index = vertexIndex - 1;
                foreach (var curEdge in Edges)
                {
                    if (curEdge.IncidentFrom == Vertices[index] || curEdge.IncidentTo == Vertices[index])
                        Edges.Remove(curEdge);
                }
                AdjacencyMatrix.RemoveAt(index);
                foreach (var row in AdjacencyMatrix)
                {
                    row.RemoveAt(index);
                }
                Vertices.RemoveAt(index);
                Size--;
            }
        }

        /// <summary>
        /// Алгоритм Крускала. Сложность 0(Е lg V).
        /// </summary>
        public void MinimumSpanningTreeKruskal()
        {
            for (int i = 0; i < Size; i++)
            {
                Vertices[i].Color = i;
            }
            Edges.Sort((e1, e2) => e1.Weight.CompareTo(e2.Weight)); // время O(ElgE)
            for (int i = 0; i < Edges.Count(); i++)
            {
                if (Edges[i].IncidentFrom.Color != Edges[i].IncidentTo.Color)
                {
                    int t = Edges[i].IncidentTo.Color;
                    for (int j = 0; j < Vertices.Count(); j++)
                    {
                        if (Vertices[j].Color == t)
                            Vertices[j].Color = Edges[i].IncidentFrom.Color;
                    }
                }
            }


            /*
             * А = 0
               2 for каждой вершины v 6 G.V
               3 Make-Set(v)
               4 Отсортировать ребра G.E в неуменьшающемся порядке по весу w
               5 for каждого ребра (и, v) 6 G.E в этом порядке
               6 if Find-Set (и) Ф Find-Set (г;)
               7 А = А и {(u,v)}
               8 Union(u,v)
               9 return А
             */
        }

        public void MinimumSpanningTreePrim() // алгоритм Прима
        {

            /*
             * for каждой вершины и Е G.V
               2 и. key = оо
               3 илг = NIL
               4 г. key — О
               5 Q = G.V
               6 while Q Ф 0
               7 и = Extract-Min(Q)
               8 for каждой вершины v Е G. Adj [it]
               9 if v E Q и w(u, v) < v. key
               10 V.7г = и
               11 v.key = w(u,v)
               // С вызовом Decrease-Key(Q, v, w(u, v))
             */
        }


        public string OutputGraph()
        {
            string adjacencyMatrixStr = "";
            foreach (var row in AdjacencyMatrix)
            {
                foreach (var edge in row)
                {
                    adjacencyMatrixStr += edge.Weight.ToString();
                    adjacencyMatrixStr += " ";
                }
                adjacencyMatrixStr += "\n";
            }

            return adjacencyMatrixStr;
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
            return AdjacencyMatrix.Count == 0;
        }
    }
}

/*public Graph(int size, string[] strs)
        {
            Size = size;
            try
            {
                int i = 0, j = 0;
                foreach (var str in strs)
                {
                    Vertex incidentFrom = new Vertex(i);
                    Vertices.Add(incidentFrom);
                    List<Edge> list = new List<Edge>();
                    var array = str.Split();
                    foreach (var item in array)
                    {
                        int intVar = int.Parse(item);
                        Edge curEdge = intVar == 0 ? new Edge(intVar) : new Edge(incidentFrom, new Vertex(j), intVar);
                        list.Add(curEdge);
                        if (intVar != 0 && i >= j)
                            Edges.Add(curEdge);
                        j++;
                    }
                    AdjacencyMatrix.Add(list);
                    i++;
                }
            }
            catch (Exception e)
            {
                if (e is NullReferenceException || e is FormatException)
                    Console.WriteLine("String is empty (Graph)");
            }

        }

            public Graph(Graph previousGraph) // Copy constructor.
        {
            AdjacencyMatrix = previousGraph.AdjacencyMatrix;
            Vertices = previousGraph.Vertices;
            Edges = previousGraph.Edges;
            Size = previousGraph.Size;
        }
 */
