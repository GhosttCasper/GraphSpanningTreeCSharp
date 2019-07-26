using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Vertex> VerticesList { get; }
        public List<Edge> EdgesList { get; set; }

        private int Size { get; set; }


        public Graph(int size, string[] strs)
        {
            Size = size;
            VerticesList = new List<Vertex>(Size);
            for (int i = 1; i <= Size; i++)
                VerticesList.Add(new Vertex(i));
            EdgesList = new List<Edge>();

            try
            {
                int curArrayIndex = 0;
                foreach (var str in strs)
                {
                    Vertex curVertexFrom = VerticesList[curArrayIndex];

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

                            if (curArrayIndex + 1 < curVertexTo.Index)
                                EdgesList.Add(new Edge(curVertexFrom, curVertexTo, intVar));
                        }

                    curArrayIndex += 1;
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

                for (int i = 0; i < EdgesList.Count; i++)
                {
                    if (EdgesList[i].First.Index == index || EdgesList[i].Second.Index == index)
                        EdgesList.RemoveAt(i);
                }
            }
            foreach (var vertexToDeleteIndex in verticesIndexes)
            {
                VerticesList.RemoveAt(vertexToDeleteIndex - 1);
            }

            Size -= 1;
        }

        /// <summary>
        /// Алгоритм Крускала. Сложность 0(Е * lgV).
        /// </summary>
        public int MinimumSpanningTreeKruskal()
        {
            EdgesList.Sort((first, second) => first.Weight.CompareTo(second.Weight)); // сортировка ребер по неубыванию

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

        public List<Edge> MinimumSpanningTreePrim() // алгоритм Прима
        {
            Vertex source = VerticesList[0];
            source.Key = 0;

            List<Vertex> verticesToAddInTree = new List<Vertex>(VerticesList);
            List<Edge> result = new List<Edge>();

            int totalWeight = 0;

            while (verticesToAddInTree.Count != 0)
            {
                Vertex curVertex = ExtractMin(verticesToAddInTree);
                totalWeight += curVertex.Key;
                foreach (var edge in curVertex.AdjacencyList)
                {
                    if (!edge.IncidentTo.Discovered && edge.Weight < edge.IncidentTo.Key)
                    {
                        edge.IncidentTo.Parent = curVertex;
                        edge.IncidentTo.Key = edge.Weight;
                        result.Add(new Edge(curVertex, edge.IncidentTo, edge.Weight));
                    }
                }
            }

            return result;
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

        public bool IsEmpty()
        {
            return VerticesList.Count == 0;
        }

        public void SaveTxtFormatGraph(string graphFile)
        {
            using (StreamWriter writer = new StreamWriter(graphFile))
            {
                writer.WriteLine(Size);
                writer.WriteLine(ToTxtFile());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var vertex in VerticesList)
            {
                foreach (var incidentEdge in vertex.AdjacencyList)
                {
                    sb.Append(vertex.Index + " ");
                    sb.Append(incidentEdge.IncidentTo.Index + " ");
                    sb.Append(incidentEdge.Weight);
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        public string ToTxtFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var edge in EdgesList)
            {
                if (edge.InTree)
                {
                    sb.Append(edge.First.Index + " ");
                    sb.Append(edge.Second.Index + " ");
                    sb.Append(edge.Weight);
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}

