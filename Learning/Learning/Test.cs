using System.Collections.Generic;
using System;
using System.Linq;

namespace Learning
{
    class Test
    {
        public List<Node> open = new List<Node>();
        public List<Node> close = new List<Node>();
        public Node[,] map;
        Node startNode = null;
        Node goalNode = null;

        public void InitializeMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new Node[this.height, this.width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = new Node();
                    map[i, j].location.y = i;
                    map[i, j].location.x = j;
                }
            }
        }

        public void SetObstacle(params Vector2[] obstaclesLoc)
        {
            foreach (var pos in obstaclesLoc)
                map[pos.y, pos.x].isObstacle = true;
        }

        public List<Node> AstarSearch(Vector2 startLoc, Vector2 endLoc)
        {
            open.Clear();
            close.Clear();
            startNode = null;
            goalNode = null;
            map[startLoc.y, startLoc.x].isStartNode = true;
            startNode = map[startLoc.y, startLoc.x];
            goalNode = map[endLoc.y, endLoc.x];
            startNode.parent = null;
            startNode.costFromStart = 0;
            startNode.costToTarget = GetDistance(startNode, goalNode);

            Node node = startNode;
            open.Add(startNode);
            while(node != goalNode)
            {
                Node temp = open[0];
                for (int i = 0; i < open.Count; i++)
                {
                    if (open[i].TotalCost < temp.TotalCost)
                        temp = open[i];
                }
                for (int i = 0; i < close.Count; i++)
                {
                    if (close[i].TotalCost < temp.TotalCost)
                        temp = close[i];
                }
                node = temp;
                var neighborhood = FindNeighborhood(node);
                for (int i = 0; i < neighborhood.Count; i++)
                {
                    double newCost = node.costFromStart + GetDistance(node, neighborhood[i]);
                    if(open.Any(o => o == neighborhood[i]))
                    {
                        if (neighborhood[i].costFromStart <= newCost) continue;
                    }
                    else
                    {
                        neighborhood[i].parent = node;
                        neighborhood[i].InitNodeData(node, goalNode);
                        if (close.Any(o => o == neighborhood[i])) close.Remove(neighborhood[i]);
                        open.Add(neighborhood[i]);
                    }
                }
                close.Add(node);
            }

            return new List<Node>(); // dummy
        }

        public  List<Node> FindNeighborhood(Node target)
        {
            List<Node> rt = new List<Node>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (target.location.y + i >= 0 && target.location.y + i <= height - 1
                        && target.location.x + j >= 0 && target.location.x + j <= width - 1)
                    {
                        if (!map[target.location.y + i, target.location.x + j].isObstacle)
                        {
                            if ((i, j) == (0, 0)) continue;
                            rt.Add(map[target.location.y + i, target.location.x + j]);
                        }
                    }
                }

            }
            return rt;
        }

        public static double GetDistance(Node node1, Node node2)
        {
            if (node1.location.x == node2.location.x) return Math.Abs(node1.location.y - node2.location.y);
            if (node1.location.y == node2.location.y) return Math.Abs(node1.location.x - node2.location.x);
            return Math.Sqrt(Math.Abs(node1.location.y - node2.location.y) + Math.Abs(node1.location.x - node2.location.x));
        }


        static Test test;
        public static Test Instance
        {
            get
            {
                if (test == null) test = new Test { width = 10, height = 10 };
                return test;
            }
        }
        public int width, height;
    }

    class Node
    {
        public Vector2 location = new Vector2();
        public double costFromStart;
        public double costToTarget;
        public double TotalCost => costFromStart + costToTarget;
        public Node parent;
        public bool isObstacle = false;
        public bool isStartNode = false;
        public bool isGoalNode = false;

        public void InitNodeData(Node preNode, Node goalNode)
        {
            costFromStart = preNode.costFromStart + Test.GetDistance(preNode, this);
            costToTarget = Test.GetDistance(this, goalNode);
        }

    }

    class Vector2
    {
        public int x, y;
    }
}
