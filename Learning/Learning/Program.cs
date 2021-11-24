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
            var test = new Test();
            test.InitializeMap(10, 10);
            IOTest.WriteSomething();
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
