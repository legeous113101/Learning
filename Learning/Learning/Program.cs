using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning
{
    class Program
    {
        public static void Main(string[] args)
        {
            //    var test = new Test();
            //    test.InitializeMap(10, 10);
            //    IOTest.WriteSomething();

            var s = "123 456 789";
            var rt = s.Split(' ');
            Console.WriteLine(rt[0]);
            Console.WriteLine(rt[1]);
            Console.WriteLine(rt[2]);
            Console.ReadLine();
        }
    }

    class IOTest
    {
        public static void WriteSomething()
        {
            string myPath = "C:/Users/Student/Desktop/TestStuff/abc.txt";
            StreamWriter writer = new StreamWriter(myPath);
            string buildString = "Hi Windows";
            writer.WriteLine(buildString);
            writer.Close();
        }
    }

}
