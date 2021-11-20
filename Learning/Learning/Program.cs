using System;
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

    class Node
    {
        Vector2 location = new Vector2();
        public double costFromStart;
        public double costFromTarget;
        public double totalCost;
        public Node parent;
        public bool isObstacle = false;
        public bool isStartNode = false;
        public bool isGoalNode = false;
    }

    class Vector2
    {
        public int x, y;
    }
}
