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
            Graph graph = ReadFileWithAdjacencyList("input.txt");
            //Console.WriteLine(graph.OutputGraph());
            List<int> verticesIndexes = ReadFileWithVertices("input2.txt");

            Graph inducedGraph = new Graph();
            if (!graph.IsEmpty())
                inducedGraph = ProcessGraph(graph, verticesIndexes);
            WriteFile(inducedGraph, "output.txt");
        }

        private static Graph ProcessGraph(Graph graph, List<int> verticesIndexes)
        {
            Graph inducedGraph = new Graph(graph); 
            inducedGraph.BuildInducedGraph(verticesIndexes);
            Console.WriteLine(graph.OutputGraph());
            Console.WriteLine(inducedGraph.OutputGraph());

            throw new NotImplementedException();
        }

        private static void WriteFile(Graph inducedGraph, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string adjacencyMatrixStr = inducedGraph.OutputGraph();
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

        private static Graph ReadFileWithAdjacencyList(string fileName)
        {
            Graph graph;
            using (StreamReader reader = new StreamReader(fileName))
            {
                int size = ReadNumber(reader);
                string[] numbersStrs = new string[size];
                for (int i = 0; i < size; i++)
                {
                    numbersStrs[i] = reader.ReadLine();
                }
                graph = new Graph(size, numbersStrs);
            }
            return graph;
        }

        private static int ReadNumber(StreamReader reader)
        {
            var numberStr = reader.ReadLine();
            if (numberStr == null)
                throw new Exception("String is empty (ReadNumber)");
            var array = numberStr.Split();
            int number = int.Parse(array[0]);
            return number;
        }

        private static Graph ReadFileWithAdjacencyMatrix(string fileName)
        {
            Graph graph;
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
                graph = new Graph(size, numbersStrs);
            }
            return graph;
        }
    }
}
