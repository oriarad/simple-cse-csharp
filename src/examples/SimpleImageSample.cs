using System;
using SimpleCSE;
using System.Drawing;

namespace SimpleCseExamples
{
    public class SimpleImageExample
    {
        static void RunALL(string[] args)
        {
            Console.WriteLine("Start");
            SimpleExample();
            SimpleExample3();
            SimpleExample4();
            SimpleExample5();
        }

        private static void SimpleExample()
        {
            SimpleImage si = new SimpleImage();
            si.Load("c:\\temp\\sample.jpg");

        }


        private static void SimpleExample3()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();

        }

        private static void SimpleExample4()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();
 
        }

        private static void SimpleExample5()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();


        }
    }
}