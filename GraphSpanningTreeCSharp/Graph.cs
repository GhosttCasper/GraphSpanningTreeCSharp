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
        public List<Vertex> VerticesList = new List<Vertex>();
        public List<Edge> EdgesList = new List<Edge>();

        private int Size;


        public Graph(int size, string[] strs)
        {
            Size = size;
            for (int i = 1; i <= Size; i++)
                VerticesList.Add(new Vertex(i));

            try
            {
                int curIndex = 0;
                foreach (var str in strs)
                {
                    Vertex curVertexFrom = VerticesList[curIndex];
                    var array = str.Split();
                    int length = array.Length;
                    if (!string.IsNullOrEmpty(str))
                        for (int i = 0; i < length; i++)
                        {
                            int intVar = int.Parse(array[i++]);
                            if (intVar > Size)
                                throw new Exception("The vertex is missing");
                            Vertex curVertexTo = VerticesList[intVar - 1];

                            intVar = int.Parse(array[i]);
                            IncidentEdge curEdge = new IncidentEdge(curVertexTo, intVar);
                            curVertexFrom.AdjacencyList.Add(curEdge);
                        }

                    curIndex += 1;
                }
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is FormatException)
                    Console.WriteLine("String is empty (Graph)"); //throw new Exception("String is empty (Graph)"); 
                else
                    throw new Exception(ex.Message);
            }
        }

        public Graph()
        {
        }

        public void BuildInducedGraph(List<int> verticesIndexes)
        {
            foreach (var index in verticesIndexes)
            {
                foreach (var incidentEdge in VerticesList[index - 1].AdjacencyList)
                {
                    var adjacencyVertex = incidentEdge.IncidentTo.AdjacencyList;
                    adjacencyVertex.Remove(adjacencyVertex.First(edge => edge.IncidentTo.Index == index));
                }
            }
            foreach (var vertexToDeleteIndex in verticesIndexes)
            {
                VerticesList.RemoveAt(vertexToDeleteIndex - 1);
            }
        }

        /// <summary>
        /// Алгоритм Крускала. Сложность 0(Е lg V).
        /// </summary>
        public int MinimumSpanningTreeKruskal()
        {
            foreach (var curVertex in VerticesList)
            {
                foreach (var incidentEdge in curVertex.AdjacencyList)
                {
                    if (curVertex.Index < incidentEdge.IncidentTo.Index)
                        EdgesList.Add(new Edge(curVertex, incidentEdge.IncidentTo, incidentEdge.Weight));
                }
            }

            EdgesList.Sort((first, second) => first.Weight.CompareTo(second.Weight));

            int totalWeight = 0;

            foreach (var edge in EdgesList)
            {
                int firstVertexColor = edge.First.Color;
                int secondVertexColor = edge.Second.Color;
                int weight = edge.Weight;

                if (firstVertexColor != secondVertexColor)
                {
                    edge.InTree = true;
                    totalWeight += weight;
                    foreach (var vertex in VerticesList)
                    {
                        if (vertex.Color == secondVertexColor)
                            vertex.Color = firstVertexColor;
                    }
                }
            }

            return totalWeight;
        }

        public List<Edge> GetMinimumSpanningTreeKruskal()
        {
            List<Edge> minimumSpanningTree = new List<Edge>();
            foreach (var edge in EdgesList)
            {
                if (edge.InTree)
                    minimumSpanningTree.Add(edge);
            }

            return minimumSpanningTree;
        }

        public int MinimumSpanningTreePrim() // алгоритм Прима
        {
            Vertex source = VerticesList[0];
            source.Key = 0;

            List<Vertex> verticesToAddInTree = new List<Vertex>(VerticesList);

            int totalWeight = 0;

            while (verticesToAddInTree.Count != 0)
            {
                Vertex curVertex = ExtractMin(verticesToAddInTree);
                totalWeight += curVertex.Key;
                foreach (var incidentEdge in curVertex.AdjacencyList)
                {
                    if (!incidentEdge.IncidentTo.Discovered && incidentEdge.Weight < incidentEdge.IncidentTo.Key) //verticesToAddInTree.Contains(incidentEdge.IncidentTo)
                    {
                        incidentEdge.IncidentTo.Parent = curVertex;
                        incidentEdge.IncidentTo.Key = incidentEdge.Weight;
                    }
                }
            }

            return totalWeight;
        }

        private Vertex ExtractMin(List<Vertex> vertices)
        {
            Vertex minVertex = vertices[0];
            int min = minVertex.Key;

            foreach (var vertex in vertices)
            {
                if (vertex.Key < min)
                {
                    min = vertex.Key;
                    minVertex = vertex;
                }
            }

            minVertex.Discovered = true;
            vertices.Remove(minVertex);
            return minVertex;
        }

        //public string OutputGraph()
        //{
        //    string adjacencyMatrixStr = "";
        //    foreach (var row in AdjacencyMatrix)
        //    {
        //        foreach (var edge in row)
        //        {
        //            adjacencyMatrixStr += edge.Weight.ToString();
        //            adjacencyMatrixStr += " ";
        //        }
        //        adjacencyMatrixStr += "\n";
        //    }
        //    return adjacencyMatrixStr;
        //}

        public bool IsEmpty()
        {
            return VerticesList.Count == 0;
        }
    }
}

