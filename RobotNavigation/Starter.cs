using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace TreeBasedSearchAssignment1
{
    public class Starter
    {
        FileReader reader;
        Agent treebased;
        Agent treebased2;
        public Starter(string textfile)
        {
            FileReader reader = new FileReader(textfile);
            reader.Read();
            List<int> gridsize = reader.getGrid();
            List<int> agentloc = reader.getAgent();
            List<int> goalloc = reader.getGoal();
            List<List<int>> walls = reader.getWall();
            treebased = new Agent(agentloc[0], agentloc[1], goalloc[0], goalloc[1], gridsize[1], gridsize[0], walls);
            treebased2 = new Agent(agentloc[0], agentloc[1], goalloc[2], goalloc[3], gridsize[1], gridsize[0], walls);

        }
        public string Draw()
        {
            return "";
        }

        public void BfsSearch()
        {
            Console.WriteLine(treebased.BfsSearch());
            Console.WriteLine("\rPress spacebar to show BFS for second goal");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            Console.WriteLine(treebased2.BfsSearch());
            Console.WriteLine("Press spacebar to exit BFS");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
        }

        public void DfsSearch()
        {
            Console.WriteLine(treebased.DfsSearch());
            Console.WriteLine("\rPress spacebar to show DFS for second goal");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            Console.WriteLine(treebased2.DfsSearch());
            Console.WriteLine("Press spacebar to exit DFS");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
        }

        public void GbfsSearch()
        {
            Console.WriteLine(treebased.GbfsSearch());
            Console.WriteLine("\rPress spacebar to show GBFS for second goal");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            Console.WriteLine(treebased2.BfsSearch());
            Console.WriteLine("Press spacebar to exit GBFS");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
        }

        public void AStarSearch()
        {
            Console.WriteLine(treebased.AStarSearch());
            Console.WriteLine("\rPress spacebar to show A* for second goal");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            Console.WriteLine(treebased2.AStarSearch());
            Console.WriteLine("Press spacebar to exit A*");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
        }

        public void UniformSearch()
        {
            Console.WriteLine(treebased.UniformSearch());
            Console.WriteLine("\rPress spacebar to show Uniform Search for second goal");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            Console.WriteLine(treebased2.UniformSearch());
            Console.WriteLine("Press spacebar to exit Uniform Search");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
        }
        public void DijkstraSearch()
        {
            Console.WriteLine(treebased.DijkstraSearch());
            Console.WriteLine("\rPress spacebar to show Dijkstra Search for second goal");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
            Console.WriteLine(treebased2.DijkstraSearch());
            Console.WriteLine("Press spacebar to exit Dijkstra Search");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
        }
    }
}