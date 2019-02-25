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
        public Dictionary<string, int> Weights = new Dictionary<string, int>();
        private int Size;
        public List<Vertex> Vertices = new List<Vertex>();


        public Graph(int size, string[] strs)
        {
            Size = size;
            for (int i = 1; i <= Size; i++)
                Vertices.Add(new Vertex(i));

            try
            {
                int index = 1;
                foreach (var str in strs)
                {
                    List<Vertex> list = new List<Vertex>();
                    var array = str.Split();
                    if (!string.IsNullOrEmpty(str))
                    {
                        bool weight = false;
                        string key = "";
                        foreach (var item in array)
                        {
                            int intVar = int.Parse(item);
                            if (!weight)
                            {
                                if (intVar > Size)
                                    throw new Exception("The vertex is missing");
                                key = index.ToString() + " " + item;
                                list.Add(Vertices[intVar - 1]);
                            }
                            else
                                Weights.Add(key, intVar);

                            weight = !weight;
                        }
                    }
                    AdjacencyList.Add(list);
                    index++;
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
            Weights = previousGraph.Weights;
            Size = previousGraph.Size;
            Vertices = previousGraph.Vertices;
        }

        public void BuildInducedGraph(List<int> verticesIndexes)
        {
            foreach (var vertexIndex in verticesIndexes)
            {
                int index = vertexIndex - 1;
                AdjacencyList.RemoveAt(index);
                Size--;
            }

            for (int i = 0; i < AdjacencyList.Count(); i++)
            {
                AdjacencyList[i] = AdjacencyList[i].Where(a => !verticesIndexes.Contains(a.Index)).ToList();
            }

            foreach (var weight in Weights)
            {
                foreach (var vertexIndex in verticesIndexes)
                {
                    if(weight.Key==vertexIndex.ToString())
                }
            }
              
        }

        /// <summary>
        /// Алгоритм Крускала. Сложность 0(Е lg V).
        /// </summary>
        public void MinimumSpanningTreeKruskal()
        {
            Weights = Weights.OrderBy(a => a.Value).ToDictionary(a => a.Key, a => a.Value); // время O(ElgE)
            foreach (var edge in Weights)
            {

            }

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
            return AdjacencyList.Count == 0;
        }
    }
}

