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

    class Program
    {
        private static void Main(string[] args)
        {
            Graph<int> graph = ReadFile("input.txt");
            List<int> verticesIndexes = ReadFileWithVertices("input2.txt");

            Graph<int> inducedGraph = new Graph<int>();
            if (graph != null && !graph.IsEmpty())
                inducedGraph = ProcessGraph(graph, verticesIndexes);
            WriteFile(inducedGraph, "output.txt");
        }

        private static Graph<int> ProcessGraph(Graph<int> graph, List<int> verticesIndexes)
        {
            throw new NotImplementedException();
        }

        private static void WriteFile(Graph<int> inducedGraph, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string adjacencyMatrixStr = "";
                foreach (var row in inducedGraph.AdjacencyMatrixRepresentation)
                {
                    foreach (var edge in row)
                    {
                        adjacencyMatrixStr += edge.Weight.ToString();
                        adjacencyMatrixStr += " ";
                    }
                    adjacencyMatrixStr += "\n";
                }
                writer.WriteLine(adjacencyMatrixStr);
            }
        }

        private static List<int> ReadFileWithVertices(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                var numbersStr = reader.ReadLine();
                if (numbersStr == null)
                    throw new Exception("String is empty (ReadFileWithVertices)");

                List<int> numbersList = new List<int>();
                var array = numbersStr.Split();
                foreach (var item in array)
                {
                    int number = int.Parse(item);
                    numbersList.Add(number);
                }
                return numbersList;
            }
        }

        private static Graph<int> ReadFile(string fileName)
        {
            Graph<int> graph = new Graph<int>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                var sizeStr = reader.ReadLine();
                if (string.IsNullOrEmpty(sizeStr))
                    throw new Exception("String is empty (ReadFile)");
                var array = sizeStr.Split();
                int size = int.Parse(array[0]);

                string[] numbersStrs = new string[size];
                for (int i = 0; i < size; i++)
                {
                    numbersStrs[i] = reader.ReadLine();
                }
                graph = new Graph<int>(size, numbersStrs);
            }
            return graph;
        }
    }
}
