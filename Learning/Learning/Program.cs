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
        Node[,] nodes;
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
        public int ManhattanDistance
        {
            get
            {
                if (x < 0 || y < 0) throw new Exception();
                int rtx = AstarTest.Instance.width - (x + 1);
                int rty = AstarTest.Instance.width - (y + 1);
                return rtx + rtx;
            }
        }
        public int cost;
        public int x = -1;
        public int y = -1;
    }
}
