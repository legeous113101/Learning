using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Program
    {

        public static void Main(string[] args)
        {
        }
    }


    class AstarTest
    {
        public List<Node> open = new List<Node>();
        public List<Node> close = new List<Node>();
        Node[,] map = null;

        public void InitializeMap(int width, int height)
        {

        }

        public void SetObstacle(Vector2[] obstaclesLoc)
        {

        }
        static AstarTest test;
        public static AstarTest Instance
        {
            get
            {
                if (test == null) test = new AstarTest {width = 10, height = 10};
                return test;
            }
        }
        public int width, height;
    }

    class Node
    {
        Vector2 location = new Vector2();
        public double costFromStart;
        public double costFromTarget;
        public double totalCost;
        public Node parent;
    }

    class Vector2
    {
        public int x, y;
    }
}
