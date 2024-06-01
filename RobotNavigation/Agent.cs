using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace TreeBasedSearchAssignment1
{
    public class Agent
    {
        private Node root;
        private int goalx, goaly, length, width;
        private int steps = 0;
        private List<List<int>> wall;
        private List<Node> wallnodes = new List<Node>();
        private Stopwatch functiontime = new Stopwatch();
        private List<Node> path = new List<Node>();

        public Agent(int rootx, int rooty, int givengoalx, int givengoaly, int givlength, int givwidth, List<List<int>> walls)
        {
            root = new Node(rootx, rooty);
            goalx = givengoalx;
            goaly = givengoaly;
            length = givlength;
            width = givwidth;
            wall = walls;

            foreach (List<int> wall in walls)
            {
                for (int i = 0; i < wall[3]; i++)
                {
                    for (int j = 0; j < wall[2]; j++)
                    {
                        wallnodes.Add(new Node(wall[0] + j, wall[1] + i));
                    }
                }
            }
        }

        public string BfsSearch()
        {
            steps = 0;
            Console.WriteLine("Currently running Bfs.");
            functiontime.Start();

            if ((root.X == goalx) && (root.Y == goaly))
            {
                functiontime.Stop();
                Console.WriteLine("Function execution time: " + functiontime.ElapsedMilliseconds / 1000 + " seconds");
                return "agent at goal already";
            }

            Queue<Node> frontier = new Queue<Node>();
            List<Node> visited = new List<Node>();
            Node currentlyvisit;

            frontier.Enqueue(root);

            while (frontier.Count != 0)
            {
                currentlyvisit = frontier.Dequeue();
                visited.Add(currentlyvisit);
                steps++;

                if (currentlyvisit.X == goalx && currentlyvisit.Y == goaly)
                {
                    List<string> travelled = new List<string>();
                    string answer = $"[{root.X},{root.Y}]";

                    while (currentlyvisit.Parent != null)
                    {
                        string direction = " ";
                        if (currentlyvisit.X == currentlyvisit.Parent.X + 1)
                            direction = "=>right=>";
                        if (currentlyvisit.X == currentlyvisit.Parent.X - 1)
                            direction = "=>left=>";
                        if (currentlyvisit.Y == currentlyvisit.Parent.Y + 1)
                            direction = "=>down=>";
                        if (currentlyvisit.Y == currentlyvisit.Parent.Y - 1)
                            direction = "=>up=>";

                        string coord = $"{direction}[{currentlyvisit.X},{currentlyvisit.Y}]";
                        travelled.Add(coord);
                        currentlyvisit = currentlyvisit.Parent;
                    }

                    travelled.Reverse();

                    foreach (string coord in travelled)
                    {
                        answer += coord;
                    }

                    functiontime.Stop();
                    Console.WriteLine("Function execution time: " + functiontime.ElapsedMilliseconds + " milliseconds");
                    string visitedstring = "";
                    foreach (Node n in visited)
                    {
                        visitedstring += $" [{n.X},{n.Y}];";
                    }
                    Console.WriteLine("Visited: " + visitedstring + "\n");

                    return $"BFS Completed;\nAgent:[{root.X},{root.Y}]\nGoal:[{goalx},{goaly}]\nPath: {answer}\nSteps: {steps}";
                }

                if (currentlyvisit.Y - 1 >= 0)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X, currentlyvisit.Y - 1, currentlyvisit));
                if (currentlyvisit.X - 1 >= 0)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X - 1, currentlyvisit.Y, currentlyvisit));
                if (currentlyvisit.Y + 1 < width)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X, currentlyvisit.Y + 1, currentlyvisit));
                if (currentlyvisit.X + 1 < length)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X + 1, currentlyvisit.Y, currentlyvisit));

                foreach (Node edgecell in currentlyvisit.Edges)
                {
                    if (!frontier.Any(node => node.X == edgecell.X && node.Y == edgecell.Y) && !((edgecell.X == root.X) && (edgecell.Y == root.Y)) && !visited.Any(node => node.X == edgecell.X && node.Y == edgecell.Y) && !wallnodes.Any(node => node.X == edgecell.X && node.Y == edgecell.Y))
                        frontier.Enqueue(edgecell);
                }
            }

            return "failed to get solution";
        }

        public string DfsSearch()
        {
            steps = 0;
            Console.WriteLine("Currently running Dfs.");
            functiontime.Start();

            if ((root.X == goalx) && (root.Y == goaly))
            {
                functiontime.Stop();
                Console.WriteLine("Function execution time: " + functiontime.ElapsedMilliseconds / 1000 + " seconds");
                return "agent at goal already";
            }

            Stack<Node> frontier = new Stack<Node>();
            List<Node> visited = new List<Node>();
            Node currentlyvisit;

            frontier.Push(root);

            while (frontier.Count != 0)
            {
                currentlyvisit = frontier.Pop();
                visited.Add(currentlyvisit);
                steps++;

                if (currentlyvisit.X == goalx && currentlyvisit.Y == goaly)
                {
                    List<string> travelled = new List<string>();
                    string answer = $"[{root.X},{root.Y}]";

                    while (currentlyvisit.Parent != null)
                    {
                        string direction = " ";
                        if (currentlyvisit.X == currentlyvisit.Parent.X + 1)
                            direction = "=>right=>";
                        if (currentlyvisit.X == currentlyvisit.Parent.X - 1)
                            direction = "=>left=>";
                        if (currentlyvisit.Y == currentlyvisit.Parent.Y + 1)
                            direction = "=>down=>";
                        if (currentlyvisit.Y == currentlyvisit.Parent.Y - 1)
                            direction = "=>up=>";

                        string coord = $"{direction}[{currentlyvisit.X},{currentlyvisit.Y}]";
                        travelled.Add(coord);
                        currentlyvisit = currentlyvisit.Parent;
                    }

                    travelled.Reverse();

                    foreach (string coord in travelled)
                    {
                        answer += coord;
                    }

                    functiontime.Stop();
                    Console.WriteLine("Function execution time: " + functiontime.ElapsedMilliseconds + " milliseconds");
                    string visitedstring = "";
                    foreach (Node n in visited)
                    {
                        visitedstring += $" [{n.X},{n.Y}];";
                    }
                    Console.WriteLine("Visited: " + visitedstring + "\n");

                    return $"DFS Completed;\nAgent:[{root.X},{root.Y}]\nGoal:[{goalx},{goaly}]\nPath: {answer}\nSteps: {steps}";
                }

                if (currentlyvisit.Y - 1 >= 0)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X, currentlyvisit.Y - 1, currentlyvisit));
                if (currentlyvisit.X - 1 >= 0)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X - 1, currentlyvisit.Y, currentlyvisit));
                if (currentlyvisit.Y + 1 < width)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X, currentlyvisit.Y + 1, currentlyvisit));
                if (currentlyvisit.X + 1 < length)
                    currentlyvisit.Edges.Add(new Node(currentlyvisit.X + 1, currentlyvisit.Y, currentlyvisit));

                foreach (Node edgecell in currentlyvisit.Edges)
                {
                    if (!frontier.Any(node => node.X == edgecell.X && node.Y == edgecell.Y) && !((edgecell.X == root.X) && (edgecell.Y == root.Y)) && !visited.Any(node => node.X == edgecell.X && node.Y == edgecell.Y) && !wallnodes.Any(node => node.X == edgecell.X && node.Y == edgecell.Y))
                        frontier.Push(edgecell);
                }
            }

            return "failed to get solution";
        }

        public string UniformSearch()
        {
            steps = 0;
            Console.WriteLine("Currently running UniformSearch.");
            functiontime.Start();

            if (root.X == goalx && root.Y == goaly)
            {
                PrintExecutionTime();
                return "agent at goal already";
            }

            var frontier = new List<Node>();
            var visited = new List<Node>();

            frontier.Add(root);

            while (frontier.Count != 0)
            {
                frontier = frontier.OrderBy(node => (Math.Abs(root.X - node.X) + Math.Abs(root.Y - node.Y))).ToList();
                var currentlyvisit = frontier.First();
                frontier.Remove(currentlyvisit);
                visited.Add(currentlyvisit);
                steps++;

                if (currentlyvisit.X == goalx && currentlyvisit.Y == goaly)
                {
                    PrintExecutionTime();
                    Console.WriteLine("Visited: " + GetVisitedNodesString(visited) + "\n");
                    return $"Uniform Cost Completed;\nAgent:[{root.X},{root.Y}]\nGoal:[{goalx},{goaly}]\nPath: {GetPathString(root, currentlyvisit)}\nSteps: {steps}";
                }

                AddAdjacentNodesToList(currentlyvisit, frontier, visited);
            }

            return "failed to get solution";
        }

        public string GbfsSearch()
        {
            steps = 0;
            Console.WriteLine("Currently running GBFS.");
            functiontime.Start();

            if (root.X == goalx && root.Y == goaly)
            {
                PrintExecutionTime();
                return "agent at goal already";
            }

            var frontier = new List<Node>();
            var visited = new List<Node>();

            frontier.Add(root);

            while (frontier.Count != 0)
            {
                frontier = frontier.OrderBy(node => (Math.Abs(goalx - node.X) + Math.Abs(goaly - node.Y))).ToList();
                var currentlyvisit = frontier.First();
                frontier.Remove(currentlyvisit);
                visited.Add(currentlyvisit);
                steps++;

                if (currentlyvisit.X == goalx && currentlyvisit.Y == goaly)
                {
                    PrintExecutionTime();
                    Console.WriteLine("Visited: " + GetVisitedNodesString(visited) + "\n");
                    return $"GBFS Completed;\nAgent:[{root.X},{root.Y}]\nGoal:[{goalx},{goaly}]\nPath: {GetPathString(root, currentlyvisit)}\nSteps: {steps}";
                }

                AddAdjacentNodesToList(currentlyvisit, frontier, visited);
            }

            return "failed to get solution";
        }

        public string AStarSearch()
        {
            steps = 0;
            Console.WriteLine("Currently running A* Search.");
            functiontime.Start();

            if (root.X == goalx && root.Y == goaly)
            {
                PrintExecutionTime();
                return "agent at goal already";
            }

            var frontier = new List<Node>();
            var visited = new List<Node>();

            frontier.Add(root);

            while (frontier.Count != 0)
            {
                frontier = frontier.OrderBy(node => (Math.Abs(root.X - node.X) + Math.Abs(root.Y - node.Y) + Math.Abs(goalx - node.X) + Math.Abs(goaly - node.Y))).ToList();
                var currentlyvisit = frontier.First();
                frontier.Remove(currentlyvisit);
                visited.Add(currentlyvisit);
                steps++;

                if (currentlyvisit.X == goalx && currentlyvisit.Y == goaly)
                {
                    PrintExecutionTime();
                    Console.WriteLine("Visited: " + GetVisitedNodesString(visited) + "\n");
                    return $"A* Search Completed;\nAgent:[{root.X},{root.Y}]\nGoal:[{goalx},{goaly}]\nPath: {GetPathString(root, currentlyvisit)}\nSteps: {steps}";
                }

                AddAdjacentNodesToList(currentlyvisit, frontier, visited);
            }

            return "failed to get solution";
        }

        public string DijkstraSearch()
        {
            steps = 0;
            Console.WriteLine("Currently running Dijkstra's Algorithm.");
            functiontime.Start();

            if (root.X == goalx && root.Y == goaly)
            {
                PrintExecutionTime();
                return "agent at goal already";
            }

            var frontier = new List<Node>();
            var visited = new List<Node>();

            frontier.Add(root);

            while (frontier.Count != 0)
            {
                
                frontier = frontier.OrderBy(node => node.Cost).ToList();
                var currentlyvisit = frontier.First();
                frontier.Remove(currentlyvisit);
                visited.Add(currentlyvisit);
                steps++;

                if (currentlyvisit.X == goalx && currentlyvisit.Y == goaly)
                {
                    PrintExecutionTime();
                    Console.WriteLine("Visited: " + GetVisitedNodesString(visited) + "\n");
                    return $"Dijkstra's Algorithm Completed;\nAgent:[{root.X},{root.Y}]\nGoal:[{goalx},{goaly}]\nPath: {GetPathString(root, currentlyvisit)}\nSteps: {steps}";
                }

                AddAdjacentNodesToList(currentlyvisit, frontier, visited);
            }

            return "failed to get solution";
        }


        private void AddAdjacentNodesToList(Node currentlyvisit, List<Node> frontier, List<Node> visited)
        {
            if (currentlyvisit.Y - 1 >= 0)
            {
                var adjacentNode = new Node(currentlyvisit.X, currentlyvisit.Y - 1, currentlyvisit);
                AddNodeToFrontier(adjacentNode, frontier, visited);
            }

            if (currentlyvisit.X - 1 >= 0)
            {
                var adjacentNode = new Node(currentlyvisit.X - 1, currentlyvisit.Y, currentlyvisit);
                AddNodeToFrontier(adjacentNode, frontier, visited);
            }

            if (currentlyvisit.Y + 1 < width)
            {
                var adjacentNode = new Node(currentlyvisit.X, currentlyvisit.Y + 1, currentlyvisit);
                AddNodeToFrontier(adjacentNode, frontier, visited);
            }

            if (currentlyvisit.X + 1 < length)
            {
                var adjacentNode = new Node(currentlyvisit.X + 1, currentlyvisit.Y, currentlyvisit);
                AddNodeToFrontier(adjacentNode, frontier, visited);
            }
        }

        private void AddNodeToFrontier(Node adjacentNode, List<Node> frontier, List<Node> visited)
        {
            if (!frontier.Any(node => node.X == adjacentNode.X && node.Y == adjacentNode.Y) && !((adjacentNode.X == root.X) && (adjacentNode.Y == root.Y)) && !visited.Any(node => node.X == adjacentNode.X && node.Y == adjacentNode.Y) && !wallnodes.Any(node => node.X == adjacentNode.X && node.Y == adjacentNode.Y))
            {
                frontier.Add(adjacentNode);
            }
        }

        private string GetPathString(Node start, Node end)
        {
            List<string> travelled = new List<string>();
            string answer = $"[{start.X},{start.Y}]";

            while (end.Parent != null)
            {
                string direction = " ";
                if (end.X == end.Parent.X + 1)
                    direction = "=>right=>";
                if (end.X == end.Parent.X - 1)
                    direction = "=>left=>";
                if (end.Y == end.Parent.Y + 1)
                    direction = "=>down=>";
                if (end.Y == end.Parent.Y - 1)
                    direction = "=>up=>";

                string coord = $"{direction}[{end.X},{end.Y}]";
                travelled.Add(coord);
                end = end.Parent;
            }

            travelled.Reverse();

            foreach (string coord in travelled)
            {
                answer += coord;
            }

            return answer;
        }

        private string GetVisitedNodesString(List<Node> visited)
        {
            string visitedstring = "";
            foreach (Node n in visited)
            {
                visitedstring += $" [{n.X},{n.Y}];";
            }
            return visitedstring;
        }

        private void PrintExecutionTime()
        {
            functiontime.Stop();
            Console.WriteLine("Function execution time: " + functiontime.ElapsedMilliseconds + " milliseconds");
        }
    }
}
