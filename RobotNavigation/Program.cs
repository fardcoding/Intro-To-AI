using System;

namespace TreeBasedSearchAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Starter agent = new Starter("test.txt");
            Console.WriteLine(" O O W W O O O G W O W");
            Console.WriteLine(" R O W W O O O O W O O");
            Console.WriteLine(" O O O O O O O O O O O");
            Console.WriteLine(" O O W O O O O O O W G");
            Console.WriteLine(" O O W W W W O O W W O");
            Console.WriteLine("1 - BFS");
            Console.WriteLine("2 - DFS");
            Console.WriteLine("3 - GBFS");
            Console.WriteLine("4 - AStar");
            Console.WriteLine("5 - Uniform Cost");
            Console.WriteLine("6 - Dijkstra Search");
            Console.WriteLine("7 - Exit");
            bool exit;
            do
            {
                string response = Console.ReadLine();
                switch (response)
                {
                    case "bfs":
                        Console.Clear();
                        agent.BfsSearch();
                        exit = false;
                        break;

                    case "dfs":
                        Console.Clear();
                        agent.DfsSearch();
                        exit = false;
                        break;

                    case "gbfs":
                        Console.Clear();
                        agent.GbfsSearch();
                        exit = false;
                        break;

                    case "astar":
                        Console.Clear();
                        agent.AStarSearch();
                        exit = false;
                        break;

                    case "uniform":
                        Console.Clear();
                        agent.UniformSearch();
                        exit = false;
                        break;

                    case "dsearch":
                        Console.Clear();
                        agent.DijkstraSearch();
                        exit= false;
                        break;

                    case "exit":
                        exit = false;
                        break;


                    default:
                        Console.Write("\rPlease enter valid response\n");
                        exit = true;
                        break;
                }

            } while (exit);


        }
    }
}
